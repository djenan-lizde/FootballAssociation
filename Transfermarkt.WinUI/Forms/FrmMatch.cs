﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Transfermarkt.Models;

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
            var leagues = await _aPIServiceLeagues.Get<List<League>>();
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

            var clubs = await _aPIServiceClub.GetById<List<ClubLeague>>(leagueId, "ClubsInLeague");

            List<Club> comboHomeTeam = new List<Club>();
            List<Club> comboAwayTeam = new List<Club>();

            foreach (var item in clubs)
            {
                var clubInDb = await _aPIServiceClub.GetById<Club>(item.ClubId);
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

            var referees = await _aPIServiceReferee.Get<List<Referee>>();
            CmbReferees.DataSource = referees;
            //dodat ime i prezime da prikazuje mapirati 
            CmbReferees.DisplayMember = "FirstName";
            CmbReferees.ValueMember = "Id";

            TxtStadium.Text = "Home stadium will load automatically.";
        }
        private async void CmbHomeClub_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var clubId = int.Parse(CmbHomeClub.SelectedValue.ToString());
            var homeClub = await _aPIServiceClub.GetById<Club>(clubId);

            if (homeClub != null)
            {
                Image image = ByteArrayToImage(homeClub.Logo);
                var newImage = ResizeImage(image);
                pictureBox1.Image = newImage;
            }

            var homeStadium = await _aPIServiceStadium.GetById<Stadium>(homeClub.Id, "HomeStadium");
            if (homeStadium == null)
            {
                TxtStadium.Text = "Home club doesn't have home stadium.";
                return;
            }
            StadiumId = homeStadium.Id;
            TxtStadium.Text = homeStadium.Name;
        }
        private async void CmbAwayClub_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var clubId = int.Parse(CmbAwayClub.SelectedValue.ToString());
            var awayClub = await _aPIServiceClub.GetById<Club>(clubId);

            if (awayClub != null)
            {
                Image image = ByteArrayToImage(awayClub.Logo);
                var newImage = ResizeImage(image);
                pictureBox2.Image = newImage;
            }
        }
        private static Image ResizeImage(Image image)
        {
            var size = new Size(200, 200);
            Image newImage = new Bitmap(image, size);
            using (Graphics graphics = Graphics.FromImage((Bitmap)newImage))
            {
                graphics.DrawImage(image, new Rectangle(Point.Empty, size));
            }
            return newImage;
        }
        private static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var gameEnd = (int.Parse(TxtMatchStart.Text.Substring(0, 2)) + 2).ToString() + TxtMatchStart.Text.Substring(2, 3);

            var match = new Match
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
            };

            var addedMatch = await _aPIServiceMatch.Insert<Match>(match);

            var refereeMatch = new RefereeMatch
            {
                RefereeId = int.Parse(CmbReferees.SelectedValue.ToString()),
                MatchId = addedMatch.Id
            };
            await _aPIServiceMatch.Insert<RefereeMatch>(refereeMatch, "RefereeMatch");
        }
    }
}
