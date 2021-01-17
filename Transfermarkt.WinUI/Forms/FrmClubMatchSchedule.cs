using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Enums;
using Transfermarkt.Models.Requests;
using Transfermarkt.WinUI.Helper;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmClubMatchSchedule : Form
    {
        private readonly APIService _apiServiceMatches = new APIService("Matches");
        private readonly APIService _apiServiceClubs = new APIService("Clubs");

        public int? Id { get; set; }

        public FrmClubMatchSchedule(int? id = null)
        {
            InitializeComponent();
            Id = id;
        }

        private async void FrmClubMatchSchedule_Load(object sender, EventArgs e)
        {
            var club = await _apiServiceClubs.GetById<Clubs>(Id);
            try
            {
                var clubMatches = await _apiServiceMatches.GetById<List<Matches>>(Id, "ClubSchedule");
                List<MatchSchedule> list = new List<MatchSchedule>();
                foreach (var item in clubMatches.OrderBy(x => x.DateGame))
                {
                    var matchDetails = await _apiServiceMatches.GetById<List<MatchDetails>>(item.Id, "MatchDetail");
                    var homeClub = await _apiServiceClubs.GetById<Clubs>(item.HomeClubId);
                    var awayClub = await _apiServiceClubs.GetById<Clubs>(item.AwayClubId);
                    var matchSchedule = new MatchSchedule
                    {
                        GameStart = $"{item.DateGame:MM/dd/yyyy} {item.GameStart}",
                        Id = item.Id
                    };
                    if (matchDetails.Count() == 0)
                    {
                        matchSchedule.MatchGame = $"{homeClub.Name} - vs - {awayClub.Name}";
                    }
                    else
                    {
                        var homeClubGoals = matchDetails.Count(x => x.ClubId == homeClub.Id && x.ActionType == (int)Enums.ActionType.Goal);
                        var awayClubGoals = matchDetails.Count(x => x.ClubId == awayClub.Id && x.ActionType == (int)Enums.ActionType.Goal);
                        matchSchedule.MatchGame = $"{homeClub.Name} {homeClubGoals} vs {awayClubGoals} {awayClub.Name}";
                    }
                    list.Add(matchSchedule);
                }
                LblClubName.Text = club.Name;
                Image image = ImageResizer.ByteArrayToImage(club.Logo);
                var newImage = ImageResizer.ResizeImage(image, 150, 150);
                PicBoxLogoClub.Image = newImage;
                DgvMatches.DataSource = list;
            }
            catch (Exception)
            {
                MessageBox.Show("This club doesn't have match schedule", "Information");
                return;
            }
        }
        private void DgvMatches_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = DgvMatches.SelectedRows[0].Cells[0].Value;
            if ((int)id == 0)
            {
                MessageBox.Show("You need to select a match.", "Error", MessageBoxButtons.OK);
                return;
            }

            FrmMatchDetail frmClubsList = new FrmMatchDetail(int.Parse(id.ToString()));
            frmClubsList.Show();
        }
    }
}
