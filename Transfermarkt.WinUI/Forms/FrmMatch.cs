using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.WinUI.Helper;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmMatch : Form
    {
        private readonly APIService _aPIServiceStadium = new APIService("Stadiums");
        private readonly APIService _aPIServiceLeagues = new APIService("Leagues");
        private readonly APIService _aPIServiceClub = new APIService("Clubs");
        private readonly APIService _aPIServiceMatch = new APIService("Matches");
        private readonly APIService _aPIServiceReferee = new APIService("Referee");

        private int StadiumId { get; set; }
        private int SeasonId { get; set; }

        public FrmMatch()
        {
            InitializeComponent();
        }
        private async void FrmMatch_Load(object sender, EventArgs e)
        {
            var leagues = await _aPIServiceLeagues.Get<List<Leagues>>();
            if (leagues.Count == 0)
            {
                MessageBox.Show("We don't have leagues", "Error");
                return;
            }
            CmbLeagues.DataSource = leagues;
            CmbLeagues.DisplayMember = "Name";
            CmbLeagues.ValueMember = "Id";

            CmbAwayClub.Enabled = false;
            CmbHomeClub.Enabled = false;
            CmbReferees.Enabled = false;
            TxtDateGame.Enabled = false;
            TxtMatchStart.Enabled = false;
        }
        private async void CmbLeagues_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var leagueId = int.Parse(CmbLeagues.SelectedValue.ToString());

            CmbAwayClub.Enabled = true;
            CmbHomeClub.Enabled = true;
            CmbReferees.Enabled = true;
            TxtDateGame.Enabled = true;
            TxtMatchStart.Enabled = true;

            var clubs = await _aPIServiceClub.GetById<List<ClubsLeague>>(leagueId, "ClubsInLeague");

            if (clubs.Count == 0)
            {
                MessageBox.Show("There are no clubs in league", "Information");
                return;
            }

            List<Clubs> comboHomeTeam = new List<Clubs>();
            List<Clubs> comboAwayTeam = new List<Clubs>();

            foreach (var item in clubs)
            {
                var clubInDb = await _aPIServiceClub.GetById<Clubs>(item.ClubId);
                comboHomeTeam.Add(clubInDb);
                comboAwayTeam.Add(clubInDb);
                SeasonId = item.SeasonId;
            }

            CmbHomeClub.DataSource = comboHomeTeam;
            CmbHomeClub.DisplayMember = "Name";
            CmbHomeClub.ValueMember = "Id";

            CmbAwayClub.DataSource = comboAwayTeam;
            CmbAwayClub.DisplayMember = "Name";
            CmbAwayClub.ValueMember = "Id";

            var referees = await _aPIServiceReferee.Get<List<Referees>>();
            if (referees.Count == 0)
            {
                MessageBox.Show("We don't have refeeres.", "Error");
                return;
            }
            CmbReferees.DataSource = referees;
            CmbReferees.DisplayMember = "FirstName";
            CmbReferees.ValueMember = "Id";

            TxtStadium.Text = "Home stadium will load automatically.";
        }
        private async void CmbHomeClub_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var clubId = int.Parse(CmbHomeClub.SelectedValue.ToString());
            var homeClub = await _aPIServiceClub.GetById<Clubs>(clubId);

            if (homeClub != null)
            {
                Image image = ImageResizer.ByteArrayToImage(homeClub.Logo);
                var newImage = ImageResizer.ResizeImage(image, 200, 200);
                pictureBox1.Image = newImage;
                var homeStadium = await _aPIServiceStadium.GetById<Stadiums>(homeClub.Id, "HomeStadium");
                if (homeStadium == null)
                {
                    TxtStadium.Text = "Home club doesn't have home stadium.";
                    return;
                }
                StadiumId = homeStadium.Id;
                TxtStadium.Text = homeStadium.Name;
            }
        }
        private async void CmbAwayClub_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var clubId = int.Parse(CmbAwayClub.SelectedValue.ToString());
            var awayClub = await _aPIServiceClub.GetById<Clubs>(clubId);

            if (awayClub != null)
            {
                Image image = ImageResizer.ByteArrayToImage(awayClub.Logo);
                var newImage = ImageResizer.ResizeImage(image, 200, 200);
                pictureBox2.Image = newImage;
            }
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var gameEnd = (int.Parse(TxtMatchStart.Text.Substring(0, 2)) + 2).ToString() + TxtMatchStart.Text.Substring(2, 3);

                var addedMatch = await _aPIServiceMatch.Insert<Matches>(new Matches
                {
                    HomeClubId = int.Parse(CmbHomeClub.SelectedValue.ToString()),
                    AwayClubId = int.Parse(CmbAwayClub.SelectedValue.ToString()),
                    DateGame = DateTime.Parse(TxtDateGame.Text),
                    IsFinished = false,
                    StadiumId = StadiumId,
                    GameStart = TxtMatchStart.Text,
                    GameEnd = gameEnd,
                    LeagueId = int.Parse(CmbHomeClub.SelectedValue.ToString()),
                    SeasonId = SeasonId
                });

                var refereeMatch = new RefereeMatches
                {
                    RefereeId = int.Parse(CmbReferees.SelectedValue.ToString()),
                    MatchId = addedMatch.Id
                };
                await _aPIServiceMatch.Insert<RefereeMatches>(refereeMatch, "RefereeMatch");
            }
        }
        private void TxtDateGame_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool success = DateTime.TryParse(TxtDateGame.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtDateGame.Text) || !success)
            {
                errorProvider.SetError(TxtDateGame, "Please insert date");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtDateGame, null);
            }
        }
        private void TxtMatchStart_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtMatchStart.Text))
            {
                errorProvider.SetError(TxtMatchStart, "Please insert when match is going to start HH:MM");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtMatchStart, null);
            }
        }
        private void CmbReferees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CmbReferees.SelectedIndex == 0 || CmbReferees.SelectedIndex == -1)
            {
                errorProvider.SetError(CmbReferees, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(CmbReferees, null);
            }
        }
        private void CmbHomeClub_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CmbHomeClub.SelectedIndex == 0 || CmbHomeClub.SelectedIndex == -1)
            {
                errorProvider.SetError(CmbHomeClub, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(CmbHomeClub, null);
            }
        }
        private void CmbAwayClub_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CmbAwayClub.SelectedIndex == 0 || CmbAwayClub.SelectedIndex == -1)
            {
                errorProvider.SetError(CmbAwayClub, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(CmbAwayClub, null);
            }
        }
    }
}
