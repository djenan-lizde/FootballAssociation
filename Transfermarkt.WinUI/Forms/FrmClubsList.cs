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
        private readonly APIService _apiServiceClubs = new APIService("Clubs");
        private readonly APIService _apiServiceMatch = new APIService("Matches");
        private readonly APIService _apiServiceSeasons = new APIService("Seasons");

        public int? LeagueId { get; set; }

        public FrmClubsList(int? leagueId = null)
        {
            InitializeComponent();
            LeagueId = leagueId;
        }
        private void DgvClubList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = DgvClubList.SelectedRows[0].Cells[0].Value;

            if ((int)id == 0)
            {
                MessageBox.Show("You need to select a club.", "Error", MessageBoxButtons.OK);
                return;
            }

            FrmClub frm = new FrmClub(int.Parse(id.ToString()));
            frm.Show();
        }
        private async void FrmClubsList_Load(object sender, EventArgs e)
        {
            CmbSeasons.DataSource = await _apiServiceSeasons.Get<List<Seasons>>();
            CmbSeasons.DisplayMember = "SeasonYear";
            CmbSeasons.ValueMember = "Id";
            var match = await _apiServiceMatch.GetById<Matches>(LeagueId, "RecommendMatch");

            var homeClub = await _apiServiceClubs.GetById<Clubs>(match.HomeClubId);
            var awayClub = await _apiServiceClubs.GetById<Clubs>(match.AwayClubId);

            TxtRecomMatch.Text = $"{homeClub.Name} - vs - {awayClub.Name} -- date: {match.DateGame.Date} {match.GameStart}";

            GenerateClubs();
        }
        private async void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSearch.Text))
            {
                GenerateClubs();
                return;
            }

            var list = await _apiServiceClubs.Get<List<Clubs>>(new ClubSearchRequest
            {
                Name = TxtSearch.Text.ToLower()
            });
            List<ClubView> clubViews = new List<ClubView>();
            foreach (var item in list)
            {
                clubViews.Add(new ClubView
                {
                    Abbreviation = item.Abbreviation,
                    Founded = item.Founded,
                    Name = item.Name,
                    Nickname = item.Nickname,
                    MarketValue = item.MarketValue,
                    Id = item.Id
                });
            }
            DgvClubList.DataSource = clubViews;
        }
        private async void GenerateClubs()
        {
            List<ClubPoints> clubs = new List<ClubPoints>();
            int counter = 0;

            var clubLeague = await _apiServiceClubs.GetById<List<ClubsLeague>>(LeagueId, "ClubsInLeague");
            foreach (var item in clubLeague)
            {
                var club = await _apiServiceClubs.GetById<Clubs>(item.ClubId);
                clubs.Add(new ClubPoints
                {
                    Abbreviation = club.Abbreviation,
                    Id = club.Id,
                    Logo = club.Logo,
                    Name = club.Name,
                    Points = item.Points,
                    Position = int.Parse(counter.ToString()) + 1
                });
            }
            DgvClubList.DataSource = clubs;
        }
        private async void CmbSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seasonId = CmbSeasons.SelectedIndex;
            if (seasonId == 0)
                return;
            var clubsInSeason = await _apiServiceClubs.GetById<List<ClubsLeague>>(seasonId, "ClubsInSeason");
            List<ClubPoints> clubPoints = new List<ClubPoints>();
            foreach (var item in clubsInSeason.Where(x => x.LeagueId == LeagueId).OrderByDescending(x => x.Points))
            {
                var club = await _apiServiceClubs.GetById<Clubs>(item.ClubId);
                clubPoints.Add(new ClubPoints
                {
                    Abbreviation = club.Abbreviation,
                    Logo = club.Logo,
                    Name = club.Name,
                    Points = item.Points,
                    Id = club.Id
                });
            }
            DgvClubList.DataSource = clubPoints;
        }
    }
}
