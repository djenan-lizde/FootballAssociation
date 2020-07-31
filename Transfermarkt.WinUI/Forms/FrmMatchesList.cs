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

                var match = new MatchesView
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
                };
                list.Add(match);
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
            var lastSeason = await _aPIServiceClubs.Get<Seasons>(null, "Season");
            var matchesSeason = await _aPIServiceMatches.GetById<List<Matches>>(lastSeason.Id, "SeasonMatches");
            foreach (var item in matchesSeason)
            {
                if (!item.IsFinished)
                {
                    MessageBox.Show("We can't create new season beacuse matches are not finished yet", "Information");
                    return;
                }
            }
            var seasonYearFirstPart = (int.Parse(lastSeason.SeasonYear.Substring(2, 2)) + 1).ToString();
            var seasonYearSecondPart = (int.Parse(lastSeason.SeasonYear.Substring(7, 2)) + 1).ToString();

            var season = new Seasons
            {
                SeasonYear = $"20{seasonYearFirstPart}/20{seasonYearSecondPart}"
            };
            var newSeason = await _aPIServiceClubs.Insert<Seasons>(season, "NewSeason");


            //points part
            var leagues = await _aPIServiceLeagues.Get<List<Leagues>>(null);

            //hard coded
            var bundesligaClubs = await _aPIServiceClubs.GetById<List<ClubsLeague>>(leagues[0].Id, "ClubsInLeague");
            var bundesliga2Clubs = await _aPIServiceClubs.GetById<List<ClubsLeague>>(leagues[1].Id, "ClubsInLeague");

            //sort po bodovima
            bundesligaClubs.OrderByDescending(x => x.Points);
            bundesliga2Clubs.OrderBy(x => x.Points);

            //sacuvamo zadnjeg i prvog na tabeli u ligama
            var lastBundesligaClub = bundesligaClubs.Last();
            var first2BundesligaClub = bundesliga2Clubs.Last();

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
                var clubLeague = new ClubsLeague
                {
                    ClubId = item.ClubId,
                    LeagueId = leagueId,
                    Points = 0,
                    SeasonId = seasonId
                };
                var lastAdded = await _aPIServiceClubs.Insert<ClubsLeague>(clubLeague, "ClubLeague");
                clubsLeagueMatches.Add(lastAdded);
            }
            GenerateGames(clubsLeagueMatches);
        }
        private async void GenerateGames(List<ClubsLeague> clubsLeagueMatches)
        {
            Random random = new Random();
            var refeeres = await _aPIServiceRefeeres.Get<List<Referees>>(null);
            foreach (var homeClub in clubsLeagueMatches)
            {
                double days = 7;
                var stadium = await _aPIServiceStadiums.GetById<Stadiums>(homeClub.ClubId, "HomeStadium");

                foreach (var awayClub in clubsLeagueMatches)
                {
                    if (homeClub.ClubId == awayClub.ClubId)
                        continue;
                    var match = new Matches
                    {
                        HomeClubId = homeClub.ClubId,
                        AwayClubId = awayClub.ClubId,
                        GameStart = "15:30",
                        GameEnd = "17:30",
                        IsFinished = false,
                        StadiumId = stadium.Id,
                        DateGame = DateTime.Now.AddDays(days)
                    };
                    var lastAddedMatch = await _aPIServiceMatches.Insert<Matches>(match);
                    days += 7;

                    var randomReferee = random.Next(0, refeeres.Count() - 1);
                    var matchReferee = new RefereeMatches
                    {
                        MatchId = lastAddedMatch.Id,
                        RefereeId = refeeres[randomReferee].Id
                    };
                    await _aPIServiceMatches.Insert<RefereeMatches>(matchReferee, "RefereeMatch");
                }
            }
        }
    }
}
