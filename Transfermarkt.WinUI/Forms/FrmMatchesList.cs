using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmMatchesList : Form
    {
        private readonly APIService _aPIServiceMatches = new APIService("Matches");
        private readonly APIService _aPIServiceClubs = new APIService("Clubs");
        private readonly APIService _aPIServiceLeagues = new APIService("Leagues");
        private readonly APIService _aPIServiceStadiums = new APIService("Stadiums");
        private readonly APIService _aPIServiceRefeeres = new APIService("Referee");
        private readonly APIService _aPIServiceSeasons = new APIService("Seasons");

        public FrmMatchesList()
        {
            InitializeComponent();
        }

        private async void FrmMatchesList_Load(object sender, EventArgs e)
        {
            var result = await _aPIServiceMatches.Get<List<Matches>>();
            if (result.Count == 0)
            {
                MessageBox.Show("We don't have matches.", "Information");
                return;
            }

            var league = await _aPIServiceLeagues.GetById<Leagues>(result[0].LeagueId);

            List<MatchesView> list = new List<MatchesView>();

            foreach (var item in result)
            {
                var homeClub = await _aPIServiceClubs.GetById<Clubs>(item.HomeClubId);
                var awayClub = await _aPIServiceClubs.GetById<Clubs>(item.AwayClubId);

                var stadium = await _aPIServiceStadiums.GetById<Clubs>(homeClub.Id, "HomeStadium");

                list.Add(new MatchesView
                {
                    Id = item.Id,
                    HomeClub = homeClub.Name,
                    AwayClub = awayClub.Name,
                    GameDate = item.DateGame,
                    GameEnd = item.GameEnd,
                    GameStart = item.GameStart,
                    IsFinished = false,
                    StadiumName = stadium.Name,
                    LeagueName = league.Name
                });
            }
            DgvMatches.DataSource = list;
        }
        private void DgvMatches_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = DgvMatches.SelectedRows[0].Cells[0].Value;

            FrmMatchDetail frm = new FrmMatchDetail(int.Parse(id.ToString()));
            frm.Show();
        }
        private async void BtnNewSeason_Click(object sender, EventArgs e)
        {
            var seasons = await _aPIServiceSeasons.Get<List<Seasons>>(null);
            var season = new Seasons();
            if (seasons.Count == 0)
            {
                season.SeasonYear = $"{DateTime.Now.Year}/{DateTime.Now.AddYears(1).Year}";

                var leagues = await _aPIServiceLeagues.Get<List<Leagues>>(null);
                var clubs = await _aPIServiceClubs.Get<List<Clubs>>(null);
                if (leagues.Count > 0 && clubs.Count > 0)
                {
                    var newSeason = await _aPIServiceSeasons.Insert<Seasons>(season);
                    var num = clubs.Count / leagues.Count;
                    if (clubs.Count % leagues.Count == 0)
                    {
                        int counter = 0;
                        for (int i = 0; i < leagues.Count; i++)
                        {
                            for (int j = counter; j < counter + num; j++)
                            {
                                await _aPIServiceClubs.Insert<ClubsLeague>(new ClubsLeague
                                {
                                    ClubId = clubs[j].Id,
                                    LastUpdate = DateTime.Now.TimeOfDay,
                                    Points = 0,
                                    SeasonId = newSeason.Id,
                                    LeagueId = leagues[i].Id
                                }, "ClubLeague");
                                if (j == counter + num - 1)
                                {
                                    var clubsInLeague = await _aPIServiceClubs.GetById<List<ClubsLeague>>(leagues[i].Id, "ClubsInLeague");
                                    GenerateGames(clubsInLeague);
                                }
                            }
                            counter += num;
                        }
                    }
                }
            }
            else
            {
                var lastSeason = seasons.LastOrDefault();
                if (lastSeason == null)
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK);
                    return;
                }

                var matchesSeason = await _aPIServiceMatches.GetById<List<Matches>>(lastSeason.Id, "SeasonMatches");
                foreach (var item in matchesSeason)
                {
                    if (!item.IsFinished)
                    {
                        MessageBox.Show("We can't create new season beacuse matches are not finished yet", "Information", MessageBoxButtons.OK);
                        return;
                    }
                }

                var seasonYearFirstPart = (int.Parse(lastSeason.SeasonYear.Substring(2, 2)) + 1).ToString();
                var seasonYearSecondPart = (int.Parse(lastSeason.SeasonYear.Substring(7, 2)) + 1).ToString();
                season.SeasonYear = $"20{seasonYearFirstPart}/20{seasonYearSecondPart}";
                var newSeason = await _aPIServiceClubs.Insert<Seasons>(season);

                var clubsInSeason = await _aPIServiceClubs.GetById<List<ClubsLeague>>(lastSeason.Id, "ClubsInSeason");
                var leagues = await _aPIServiceLeagues.Get<List<Leagues>>(null);

                var list = new List<ClubsLeague>();
                for (int i = 0; i < leagues.Count; i++)
                {
                    for (int j = 0; j < clubsInSeason.Where(x => x.LeagueId == leagues[i].Id).OrderByDescending(x => x.Points).Count(); j++)
                    {
                        var clubLeague = new ClubsLeague
                        {
                            ClubId = clubsInSeason[j].ClubId,
                            LastUpdate = DateTime.Now.TimeOfDay,
                            Points = 0,
                            SeasonId = newSeason.Id
                        };
                        if (j == 0 && i == 0)
                        {
                            clubLeague.LeagueId = leagues[i].Id;
                        }
                        else if (j == 0 && i != 0)
                        {
                            clubLeague.LeagueId = leagues[i - 1].Id;
                        }
                        else if (j == clubsInSeason.Count - 1)
                        {
                            clubLeague.LeagueId = leagues[i + 1].Id;
                        }
                        else if (i == leagues.Count - 1 && j == clubsInSeason.Count - 1)
                        {
                            clubLeague.LeagueId = leagues[i].Id;
                        }
                        await _aPIServiceClubs.Insert<ClubsLeague>(clubLeague, "ClubLeague");
                        list.Add(await _aPIServiceClubs.Insert<ClubsLeague>(clubLeague, "ClubLeague"));
                    }
                }
                GenerateGames(list);
            }
        }
        private async void GenerateGames(List<ClubsLeague> clubsLeagueMatches)
        {
            Random random = new Random();
            var refeeres = await _aPIServiceRefeeres.Get<List<Referees>>(null);
            double days = 7;
            if (refeeres.Count > 0)
            {
                foreach (var homeClub in clubsLeagueMatches)
                {
                    var stadium = await _aPIServiceStadiums.GetById<Stadiums>(homeClub.ClubId, "HomeStadium");
                    if (stadium != null)
                    {
                        foreach (var awayClub in clubsLeagueMatches)
                        {
                            if (homeClub.ClubId == awayClub.ClubId)
                                continue;
                            var lastAddedMatch = await _aPIServiceMatches.Insert<Matches>(new Matches
                            {
                                HomeClubId = homeClub.ClubId,
                                AwayClubId = awayClub.ClubId,
                                GameStart = "15:30",
                                GameEnd = "17:30",
                                IsFinished = false,
                                StadiumId = stadium.Id,
                                DateGame = DateTime.Now.AddDays(days),
                                LeagueId = homeClub.LeagueId,
                                SeasonId = homeClub.SeasonId
                            });
                            days += 7;

                            var randomReferee = random.Next(0, refeeres.Count - 1);
                            await _aPIServiceMatches.Insert<RefereeMatches>(new RefereeMatches
                            {
                                MatchId = lastAddedMatch.Id,
                                RefereeId = refeeres[randomReferee].Id
                            }, "RefereeMatch");
                        }
                    }
                }
            }
        }
    }
}
