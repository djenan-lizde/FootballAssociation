using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Transfermarkt.Models;
using Transfermarkt.Models.Enums;
using Transfermarkt.Models.Requests;
using Xamarin.Forms;

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
            var matches = await _apiServiceMatches.GetById<List<Matches>>(ClubId, "ClubSchedule");
            if (matches.Count > 0)
            {
                Matches.Clear();

                foreach (var item in matches)
                {
                    var matchDetails = await _apiServiceMatches.GetById<List<MatchDetails>>(item.Id, "MatchDetail");
                    var homeClub = await _apiServiceClubs.GetById<Clubs>(item.HomeClubId);
                    var awayClub = await _apiServiceClubs.GetById<Clubs>(item.AwayClubId);
                    if (homeClub != null && awayClub != null)
                    {
                        var matchSchedule = new MatchSchedule
                        {
                            GameStart = $"{item.DateGame:MM/dd/yyyy} {item.GameStart}",
                            Id = item.Id
                        };
                        if (matchDetails.Count == 0)
                        {
                            matchSchedule.MatchGame = $"{homeClub.Name} - vs - {awayClub.Name}";
                        }
                        else
                        {
                            var homeClubGoals = matchDetails.Count(x => x.ClubId == homeClub.Id && x.ActionType == (int)Enums.ActionType.Goal);
                            var awayClubGoals = matchDetails.Count(x => x.ClubId == awayClub.Id && x.ActionType == (int)Enums.ActionType.Goal);
                            matchSchedule.MatchGame = $"{homeClub.Name} {homeClubGoals} vs {awayClubGoals} {awayClub.Name}";
                        }
                        Matches.Add(matchSchedule);
                    }
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Infromation", "We don't have matches for this club", "OK");
            }
        }
    }
}
