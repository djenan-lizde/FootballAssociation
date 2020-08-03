using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Transfermarkt.MobileApp.Views;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Xamarin.Forms;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class ClubDetailsViewModel : BaseViewModel
    {
        private readonly APIService _apiServicePlayers = new APIService("Players");
        private readonly APIService _apiServiceContracts = new APIService("Contracts");

        public ClubDetailsViewModel()
        {
            InitCommand = new Command(async () => await ClubPlayers());
        }

        public ClubPoints Club { get; set; }

        public ObservableCollection<PlayersClub> Players { get; set; } = new ObservableCollection<PlayersClub>();

        public async Task ClubPlayers()
        {
            var contracts = await _apiServiceContracts.GetById<List<Contracts>>(Club.Id, "ClubContracts");
            Players.Clear();

            foreach (var item in contracts)
            {
                var player = await _apiServicePlayers.GetById<Players>(item.PlayerId);

                Players.Add(new PlayersClub
                {
                    Id = item.PlayerId,
                    Birthdate = player.Birthdate,
                    FirstName = player.FirstName,
                    Jersey = player.Jersey,
                    LastName = player.LastName
                });
            }
        }
        public ICommand InitCommand { get; set; }
    }
}
