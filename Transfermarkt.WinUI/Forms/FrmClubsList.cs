using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmClubsList : Form
    {
        private readonly APIService _ApiServiceClubs = new APIService("Clubs");

        public int? LeagueId { get; set; }

        public FrmClubsList(int? leagueId = null)
        {
            InitializeComponent();
            LeagueId = leagueId;
        }
        private void DgvClubList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = DgvClubList.SelectedRows[0].Cells[0].Value;

            FrmClub frm = new FrmClub(int.Parse(id.ToString()));
            frm.Show();
        }
        private async void FrmClubsList_Load(object sender, EventArgs e)
        {
            CmbSeasons.DataSource = await _ApiServiceClubs.Get<List<Season>>(null, "AllSeasons");
            CmbSeasons.DisplayMember = "SeasonYear";
            CmbSeasons.ValueMember = "Id";
            GenerateClubs();
        }
        private async void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSearch.Text))
            {
                GenerateClubs();
                return;
            }
            var request = new ClubSearchRequest
            {
                Name = TxtSearch.Text.ToLower()
            };
            var list = await _ApiServiceClubs.Get<List<Club>>(request, "ClubSearch");
            List<ClubView> clubViews = new List<ClubView>();
            foreach (var item in list)
            {
                var club = new ClubView
                {
                    Abbreviation = item.Abbreviation,
                    Founded = item.Founded,
                    Name = item.Name,
                    Nickname = item.Nickname,
                    MarketValue = item.MarketValue,
                    Id = item.Id
                };
                clubViews.Add(club);
            }
            DgvClubList.DataSource = clubViews;
        }
        private async void GenerateClubs()
        {
            List<ClubPoints> clubs = new List<ClubPoints>();
            int counter = 0;

            var clubLeague = await _ApiServiceClubs.GetById<List<ClubLeague>>(LeagueId, "ClubsInLeague");
            foreach (var item in clubLeague.OrderByDescending(x => x.Points))
            {
                var club = await _ApiServiceClubs.GetById<Club>(item.ClubId);
                var points = await _ApiServiceClubs.GetById<ClubLeague>(item.ClubId, "ClubPoints");
                var clubView = new ClubPoints
                {
                    Abbreviation = club.Abbreviation,
                    Id = club.Id,
                    Logo = club.Logo,
                    Name = club.Name,
                    Points = points.Points,
                    Position = int.Parse(counter.ToString()) + 1
                };
                clubs.Add(clubView);
            }
            DgvClubList.DataSource = clubs;
        }
        private async void CmbSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            //testirati
            int seasonId = CmbSeasons.SelectedIndex;
            if (seasonId == 0)
                return;
            var clubsInSeason = await _ApiServiceClubs.GetById<List<ClubLeague>>(seasonId, "ClubsInSeason");
            List<ClubPoints> clubPoints = new List<ClubPoints>();
            foreach (var item in clubsInSeason.Where(x => x.LeagueId == LeagueId).OrderByDescending(x => x.Points))
            {
                var club = await _ApiServiceClubs.GetById<Club>(item.ClubId);
                var clubView = new ClubPoints
                {
                    Abbreviation = club.Abbreviation,
                    Logo = club.Logo,
                    Name = club.Name,
                    Points = item.Points,
                    Id = club.Id
                };
                clubPoints.Add(clubView);
            }
            DgvClubList.DataSource = clubPoints;
        }
    }
}
