using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class MatchesViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceLeagues = new APIService("Leagues");
        private readonly APIService _apiServiceMatches = new APIService("Matches");
        private readonly APIService _apiServiceClubs = new APIService("Clubs");
        private readonly APIService _aPIServiceStadiums = new APIService("Stadiums");

        public MatchesViewModel()
        {

        }

        public ObservableCollection<MatchesView> MatchesList { get; set; } = new ObservableCollection<MatchesView>();

        public async void Init()
        {
            var result = await _apiServiceMatches.Get<List<Match>>();
            var clubLeagues = await _apiServiceClubs.Get<List<ClubLeague>>(null, "ClubLeague");

            foreach (var item in result)
            {
                var homeClubLeague = clubLeagues.FirstOrDefault(x => x.Id == item.HomeClubId);
                var awayClubLeague = clubLeagues.FirstOrDefault(x => x.Id == item.AwayClubId);

                var homeClub = await _apiServiceClubs.GetById<Club>(homeClubLeague.ClubId);
                var awayClub = await _apiServiceClubs.GetById<Club>(awayClubLeague.ClubId);

                var stadium = await _aPIServiceStadiums.GetById<Club>(homeClubLeague.ClubId, "HomeStadium");

                var match = new MatchesView
                {
                    Id = item.Id,
                    HomeClub = homeClub.Name,
                    AwayClub = awayClub.Name,
                    GameDate = item.DateGame,
                    GameEnd = item.GameEnd,
                    GameStart = item.GameEnd,
                    IsFinished = false,
                    StadiumName = stadium.Name
                };
                MatchesList.Add(match);
            }
        }
    }
}
