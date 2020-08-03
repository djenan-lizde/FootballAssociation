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
        private readonly APIService _apiServiceMatches = new APIService("Matches");
        private readonly APIService _apiServiceClubs = new APIService("Clubs");
        private readonly APIService _aPIServiceStadiums = new APIService("Stadiums");
        private readonly APIService _aPIServiceLeagues = new APIService("Leagues");

        public MatchesViewModel()
        {

        }

        public ObservableCollection<MatchesView> MatchesList { get; set; } = new ObservableCollection<MatchesView>();

        public async void Init()
        {
            var result = await _apiServiceMatches.Get<List<Matches>>();
            if (result.Count() == 0)
            {
                return;
            }
            MatchesList.Clear();

            var league = await _aPIServiceLeagues.GetById<Leagues>(result[0].LeagueId);

            foreach (var item in result)
            {
                var homeClub = await _apiServiceClubs.GetById<Clubs>(item.HomeClubId);
                var awayClub = await _apiServiceClubs.GetById<Clubs>(item.AwayClubId);

                var stadium = await _aPIServiceStadiums.GetById<Clubs>(homeClub.Id, "HomeStadium");

                MatchesList.Add(new MatchesView
                {
                    Id = item.Id,
                    HomeClub = homeClub.Name,
                    AwayClub = awayClub.Name,
                    GameDate = item.DateGame,
                    GameEnd = item.GameEnd,
                    GameStart = item.GameEnd,
                    IsFinished = false,
                    StadiumName = stadium.Name,
                    LeagueName = league.Name
                });
            }
        }
    }
}
