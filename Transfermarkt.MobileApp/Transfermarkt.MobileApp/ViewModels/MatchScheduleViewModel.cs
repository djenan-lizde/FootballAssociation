using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class MatchScheduleViewModel
    {
        private readonly APIService _apiServiceMatches = new APIService("Matches");
        private readonly APIService _apiServiceClubs = new APIService("Clubs");


        public MatchScheduleViewModel() { }
        public int ClubId { get; set; }
        public ObservableCollection<MatchSchedule> Matches { get; set; } = new ObservableCollection<MatchSchedule>();

        public async Task Init()
        {
            var matches = await _apiServiceMatches.GetById<List<Match>>(ClubId, "ClubSchedule");
            Matches.Clear();

            foreach (var item in matches)
            {
                var matchDetails = await _apiServiceMatches.GetById<List<MatchDetail>>(item.Id, "MatchDetail");
                var homeClub = await _apiServiceClubs.GetById<Club>(item.HomeClubId);
                var awayClub = await _apiServiceClubs.GetById<Club>(item.AwayClubId);
                var matchSchedule = new MatchSchedule
                {
                    GameDate = item.DateGame,
                    Id = item.Id
                };
                if (matchDetails.Count() == 0)
                {
                    matchSchedule.MatchGame = $"{homeClub.Name} - vs - {awayClub.Name}";
                }
                else
                {
                    var homeClubGoals = matchDetails.Count(x => x.ClubId == homeClub.Id && x.ActionType == 3);
                    var awayClubGoals = matchDetails.Count(x => x.ClubId == awayClub.Id && x.ActionType == 3);
                    matchSchedule.MatchGame = $"{homeClub.Name} {homeClubGoals} vs {awayClubGoals} {awayClub.Name}";
                }
                Matches.Add(matchSchedule);
            }
        }
    }
}
