using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Transfermarkt.Models;
using Transfermarkt.Models.Enums;
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

            if (matchDetails.Count >= 0)
            {
                var HomeClubName = await _aPIServiceClubs.GetById<Clubs>(match.HomeClubId);
                var AwayClubName = await _aPIServiceClubs.GetById<Clubs>(match.AwayClubId);
                if (HomeClubName != null && AwayClubName != null)
                {
                    var HomeClubGoals = matchDetails.Count(x => x.ClubId == HomeClubName.Id && x.ActionType == 3);
                    var AwayClubGoals = matchDetails.Count(x => x.ClubId == AwayClubName.Id && x.ActionType == 3);

                    if (match.IsFinished)
                        TeamsMatchResult = $"{HomeClubName.Name} {HomeClubGoals} : {AwayClubGoals} {AwayClubName.Name}";
                    else
                        TeamsMatchResult = $"{HomeClubName.Name} - : - {AwayClubName.Name}";


                    GoalScorers.Clear();
                    PlayersCards.Clear();
                    PlayersCorners.Clear();

                    //goals
                    if (matchDetails.Count(x => x.ActionType == (int)Enums.ActionType.Goal) > 0)
                    {
                        foreach (var item in matchDetails.Where(x => x.ActionType == (int)Enums.ActionType.Goal))
                        {
                            var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                            var club = await _aPIServiceClubs.GetById<Clubs>(item.ClubId);
                            if (player != null && club != null)
                            {
                                GoalScorers.Add(new GoalScorer
                                {
                                    ClubName = club.Name,
                                    Minute = item.Minute,
                                    PlayerFullName = $"{player.FirstName} {player.LastName}"
                                });
                            }
                        }
                    }

                    //cards
                    if ((matchDetails.Count(x => x.ActionType == (int)Enums.ActionType.YellowCard) > 0)
                        || (matchDetails.Count(x => x.ActionType == (int)Enums.ActionType.RedCard) > 0))
                    {
                        foreach (var item in matchDetails.Where(x => x.ActionType == (int)Enums.ActionType.YellowCard || x.ActionType == (int)Enums.ActionType.RedCard))
                        {
                            var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                            var club = await _aPIServiceClubs.GetById<Clubs>(item.ClubId);
                            if (player != null && club != null)
                            {
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
                    }

                    //corners
                    if (matchDetails.Count(x => x.ActionType == (int)Enums.ActionType.CornerOccurred) >= 0)
                    {
                        foreach (var item in matchDetails.Where(x => x.ActionType == (int)Enums.ActionType.CornerOccurred))
                        {
                            var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                            var club = await _aPIServiceClubs.GetById<Clubs>(item.ClubId);
                            if (player != null && club != null)
                            {
                                PlayersCorners.Add(new PlayersCorners
                                {
                                    ClubName = club.Name,
                                    PlayerFullName = $"{player.FirstName} {player.LastName}",
                                    Minute = item.Minute
                                });
                            }
                        }
                    }
                }
            }
        }
    }
}
