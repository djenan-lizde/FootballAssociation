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

        private async void FrmClubsList_Load(object sender, EventArgs e)
        {
            try
            {
                TxtRecomMatch.ReadOnly = true;

                var seasons = await _apiServiceSeasons.Get<List<Seasons>>();
                seasons.Insert(0, new Seasons());
                CmbSeasons.DataSource = seasons;
                CmbSeasons.DisplayMember = "SeasonYear";
                CmbSeasons.ValueMember = "Id";

                var match = await _apiServiceMatch.GetById<Matches>(LeagueId, "RecommendMatch");

                if (match != null)
                {
                    var homeClub = await _apiServiceClubs.GetById<Clubs>(match.HomeClubId);
                    var awayClub = await _apiServiceClubs.GetById<Clubs>(match.AwayClubId);

                    TxtRecomMatch.Text = $"{homeClub.Name} - vs - {awayClub.Name} -- date: {match.DateGame.Date} {match.GameStart}";
                }
            }
            catch (Exception)
            {
                TxtSearch.ReadOnly = true;
                MessageBox.Show("There is no ongoing or upcoming matches", "Information", MessageBoxButtons.OK);
                return;
            }

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
                counter += 1;
                var club = await _apiServiceClubs.GetById<Clubs>(item.ClubId);
                clubs.Add(new ClubPoints
                {
                    Abbreviation = club.Abbreviation,
                    Id = club.Id,
                    Logo = club.Logo,
                    Name = club.Name,
                    Points = item.Points,
                    Position = counter
                });
            }
            DgvClubList.DataSource = clubs;
        }
        private async void CmbSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int seasonId = (int)CmbSeasons.SelectedValue;
                if (seasonId == 0)
                    return;
                var clubsInSeason = await _apiServiceClubs.GetById<List<ClubsLeague>>(seasonId, "ClubsInSeason");
                if (clubsInSeason.Count == 0)
                {
                    MessageBox.Show("There is no clubs in this season", "Information");
                    return;
                }
                List<ClubPoints> clubPoints = new List<ClubPoints>();
                int counter = 1;
                foreach (var item in clubsInSeason.Where(x => x.LeagueId == LeagueId).OrderByDescending(x => x.Points))
                {
                    var club = await _apiServiceClubs.GetById<Clubs>(item.ClubId);
                    if (club != null)
                    {
                        clubPoints.Add(new ClubPoints
                        {
                            Abbreviation = club.Abbreviation,
                            Logo = club.Logo,
                            Name = club.Name,
                            Points = item.Points,
                            Id = club.Id,
                            Position = counter
                        });
                    }
                    counter += 1;
                }
                DgvClubList.DataSource = clubPoints;
                TxtSearch.ReadOnly = false;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
