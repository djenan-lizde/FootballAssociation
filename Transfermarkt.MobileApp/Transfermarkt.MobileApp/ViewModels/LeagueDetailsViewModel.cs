using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class LeagueDetailsViewModel
    {
        private readonly APIService _apiServiceClubs = new APIService("Clubs");

        public LeagueDetailsViewModel() { }

        public League selectedLeague;

        public ObservableCollection<ClubPoints> ClubsList { get; set; } = new ObservableCollection<ClubPoints>();

        public async Task Init()
        {
            var clubLeague = await _apiServiceClubs.GetById<List<ClubLeague>>(selectedLeague.Id, "ClubsInLeague");

            foreach (var item in clubLeague.OrderByDescending(x => x.Points))
            {
                var club = await _apiServiceClubs.GetById<Club>(item.ClubId);
                var clubPoint = new ClubPoints
                {
                    Points = item.Points,
                    Id = club.Id,
                    Logo = club.Logo,
                    Name = club.Name,
                    Abbreviation = club.Abbreviation
                };
                ClubsList.Add(clubPoint);
            }
        }
    }
}
