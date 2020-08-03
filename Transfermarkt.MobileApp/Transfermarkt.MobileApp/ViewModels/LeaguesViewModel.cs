using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Transfermarkt.Models;
using Xamarin.Forms;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class LeaguesViewModel
    {
        private readonly APIService _apiServiceLeagues = new APIService("Leagues");

        public LeaguesViewModel(){}

        public async Task Init()
        {
            var leaguesList = await _apiServiceLeagues.Get<List<Leagues>>(null);
            LeaguesList.Clear();
            foreach (var item in leaguesList)
            {
                LeaguesList.Add(item);
            }
        }

        public ObservableCollection<Leagues> LeaguesList { get; set; } = new ObservableCollection<Leagues>();
    }
}
