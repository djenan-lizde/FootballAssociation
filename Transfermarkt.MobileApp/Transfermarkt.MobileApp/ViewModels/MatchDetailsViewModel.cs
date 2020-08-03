using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class MatchDetailsViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceMatches = new APIService("Matches");
        private readonly APIService _aPIServiceClubs = new APIService("Clubs");
        private readonly APIService _aPIServicePlayers = new APIService("Players");

        public MatchSchedule Match { get; set; }
        public ObservableCollection<GoalScorer> GoalScorers { get; set; } = new ObservableCollection<GoalScorer>();
        public ObservableCollection<PlayersCards> PlayersCards { get; set; } = new ObservableCollection<PlayersCards>();
        public ObservableCollection<PlayersCorners> PlayersCorners { get; set; } = new ObservableCollection<PlayersCorners>();

        string teamsMatchResult = string.Empty;
        public string TeamsMatchResult
        {
            get { return teamsMatchResult; }
            set { SetProperty(ref teamsMatchResult, value); }
        }

        public async Task Init()
        {
            var match = await _apiServiceMatches.GetById<Matches>(Match.Id);
            var matchDetails = await _apiServiceMatches.GetById<List<MatchDetails>>(Match.Id, "MatchDetail");

            var HomeClubName = await _aPIServiceClubs.GetById<Clubs>(match.HomeClubId);
            var AwayClubName = await _aPIServiceClubs.GetById<Clubs>(match.AwayClubId);
            var HomeClubGoals = GetMatchDetails(matchDetails, match.HomeClubId, 3);
            var AwayClubGoals = GetMatchDetails(matchDetails, match.AwayClubId, 3);

            if (match.IsFinished)
                TeamsMatchResult = $"{HomeClubName.Name} {HomeClubGoals} : {AwayClubGoals} {AwayClubName.Name}";
            else
                TeamsMatchResult = $"{HomeClubName.Name} - : - {AwayClubName.Name}";


            GoalScorers.Clear();
            PlayersCards.Clear();
            PlayersCorners.Clear();

            //goals
            if (matchDetails.Count(x => int.Parse(x.ActionType.ToString()) == 3) > 0)
            {
                foreach (var item in matchDetails)
                {
                    var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                    var club = await _aPIServiceClubs.GetById<Clubs>(item.ClubId);
                    GoalScorers.Add(new GoalScorer
                    {
                        ClubName = club.Name,
                        Minute = item.Minute,
                        PlayerFullName = $"{player.FirstName} {player.LastName}"
                    });
                }
            }

            //cards
            if ((matchDetails.Count(x => int.Parse(x.ActionType.ToString()) == 0) > 0)
                || (matchDetails.Count(x => int.Parse(x.ActionType.ToString()) == 1) > 0))
            {
                foreach (var item in matchDetails)
                {
                    var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                    var club = await _aPIServiceClubs.GetById<Clubs>(item.ClubId);
                    var playerCard = new PlayersCards
                    {
                        ClubName = club.Name,
                        PlayerFullName = $"{player.FirstName} {player.LastName}",
                        Minute = item.Minute
                    };
                    if (item.ActionType == 0)
                        playerCard.Card = "Yellow card";
                    else
                        playerCard.Card = "Red card";
                    PlayersCards.Add(playerCard);
                }
            }

            //corners
            if (matchDetails.Count(x => int.Parse(x.ActionType.ToString()) == 2) >= 0)
            {
                foreach (var item in matchDetails)
                {
                    var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                    var club = await _aPIServiceClubs.GetById<Clubs>(item.ClubId);
                    PlayersCorners.Add(new PlayersCorners
                    {
                        ClubName = club.Name,
                        PlayerFullName = $"{player.FirstName} {player.LastName}",
                        Minute = item.Minute
                    });
                }
            }
        }

        private int GetMatchDetails(List<MatchDetails> list, int clubId, int enumValue)
        {
            var clubStats = list.Count(x => x.ClubId == clubId
                && int.Parse(x.ActionType.ToString()) == enumValue);
            return int.Parse(clubStats.ToString());
        }
    }
}
