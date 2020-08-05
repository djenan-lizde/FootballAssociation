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
        private readonly APIService _aPIServiceRefeeres = new APIService("Refeere");

        public FrmMatchesList()
        {
            InitializeComponent();
        }

        private async void FrmMatchesList_Load(object sender, EventArgs e)
        {
            var result = await _aPIServiceMatches.Get<List<Matches>>();
            if (result.Count() == 0)
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
            var seasons = await _aPIServiceClubs.Get<List<Seasons>>(null);
            var season = new Seasons();
            if (seasons.Count == 0)
            {
                season.SeasonYear = $"{DateTime.Now.Year}/{DateTime.Now.AddYears(1)}";

                var leagues2 = await _aPIServiceLeagues.Get<List<Leagues>>(null);

                if (leagues2.Count <= 0)
                {
                    var newSeason2 = await _aPIServiceClubs.Insert<Seasons>(season);
                    var clubs2 = await _aPIServiceClubs.Get<List<Clubs>>(null);
                    var numClubs = clubs2.Count;
                    for (int i = 0; i < clubs2.Count; i++)
                    {
                        var clubLeague2 = new ClubsLeague
                        {
                            ClubId = clubs2[i].Id,
                            LastUpdate = DateTime.Now.TimeOfDay,
                            Points = 0,
                            SeasonId = newSeason2.Id
                        };

                    }
                }
            }
            else
            {
                var lastSeason = seasons.LastOrDefault();
                var seasonYearFirstPart = (int.Parse(lastSeason.SeasonYear.Substring(2, 2)) + 1).ToString();
                var seasonYearSecondPart = (int.Parse(lastSeason.SeasonYear.Substring(7, 2)) + 1).ToString();
                season.SeasonYear = $"20{seasonYearFirstPart}/20{seasonYearSecondPart}";

                var matchesSeason = await _aPIServiceMatches.GetById<List<Matches>>(lastSeason.Id, "SeasonMatches");
                foreach (var item in matchesSeason)
                {
                    if (!item.IsFinished)
                    {
                        MessageBox.Show("We can't create new season beacuse matches are not finished yet", "Information");
                        return;
                    }
                }
            }

            var leagues = await _aPIServiceLeagues.Get<List<Leagues>>(null);
            if (leagues.Count == 0 || leagues.Count == 1)
            {
                MessageBox.Show("We need at least two leagues, so we could create new season. Please insert league/s.", "Information",
                     MessageBoxButtons.OK);
                return;
            }

            //hard coded
            var bundesligaClubs = await _aPIServiceClubs.GetById<List<ClubsLeague>>(leagues[0].Id, "ClubsInLeague");
            var bundesliga2Clubs = await _aPIServiceClubs.GetById<List<ClubsLeague>>(leagues[1].Id, "ClubsInLeague");

            var newSeason = await _aPIServiceClubs.Insert<Seasons>(season);

            if (bundesligaClubs.Count == 0 && bundesliga2Clubs.Count == 0)
            {
                var clubs = await _aPIServiceClubs.Get<List<Clubs>>(null);
                if (clubs.Count % 2 == 0)
                {
                    List<ClubsLeague> clubsLeagueMatches = new List<ClubsLeague>();
                    for (int i = 0; i < clubs.Count; i++)
                    { 
                        var clubLeagueSeason = new ClubsLeague
                        {
                            ClubId = clubs[i].Id,
                            Points = 0,
                            SeasonId = newSeason.Id,
                            LastUpdate = DateTime.Now.TimeOfDay
                        };
                        if (i <= clubs.Count / 2)
                        {
                            clubLeagueSeason.LeagueId = leagues[0].Id;
                        }
                        else
                        {
                            clubLeagueSeason.LeagueId = leagues[1].Id;
                        }
                        var clubsLeague = await _aPIServiceClubs.Insert<ClubsLeague>(clubLeagueSeason, "ClubLeague");
                        clubsLeagueMatches.Add(clubsLeague);
                    }
                    GenerateGames(clubsLeagueMatches);
                }
            }

            //sort po bodovima
            var lastBundesligaClub = bundesligaClubs.OrderByDescending(x => x.Points).Last();
            var first2BundesligaClub = bundesliga2Clubs.OrderBy(x => x.Points).Last();

            //uklonimo zadnjeg na tabeli
            bundesligaClubs.RemoveAt(bundesligaClubs.Count() - 1);
            //uklonimo prvog na tabeli
            bundesliga2Clubs.RemoveAt(bundesliga2Clubs.Count() - 1);

            //klubovi koji su promijenili ligu dodaju se u novu listu kojoj pripadaju
            bundesligaClubs.Add(first2BundesligaClub);
            bundesliga2Clubs.Add(lastBundesligaClub);

            //insert klubova u nove lige i sezone
            InsertClubInLeague(bundesligaClubs, leagues[0].Id, newSeason.Id);
            InsertClubInLeague(bundesliga2Clubs, leagues[1].Id, newSeason.Id);
        }
        private async void InsertClubInLeague(List<ClubsLeague> clubLeagues, int leagueId, int seasonId)
        {
            List<ClubsLeague> clubsLeagueMatches = new List<ClubsLeague>();
            foreach (var item in clubLeagues)
            {
                var lastAdded = await _aPIServiceClubs.Insert<ClubsLeague>(new ClubsLeague
                {
                    ClubId = item.ClubId,
                    LeagueId = leagueId,
                    Points = 0,
                    SeasonId = seasonId
                }, "ClubLeague");
                clubsLeagueMatches.Add(lastAdded);
            }
            GenerateGames(clubsLeagueMatches);
        }
        private async void GenerateGames(List<ClubsLeague> clubsLeagueMatches)
        {
            Random random = new Random();
            var refeeres = await _aPIServiceRefeeres.Get<List<Referees>>(null);
            double days = 7;

            foreach (var homeClub in clubsLeagueMatches)
            {
                var stadium = await _aPIServiceStadiums.GetById<Stadiums>(homeClub.ClubId, "HomeStadium");

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
                        DateGame = DateTime.Now.AddDays(days)
                    });
                    days += 7;

                    var randomReferee = random.Next(0, refeeres.Count() - 1);
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
