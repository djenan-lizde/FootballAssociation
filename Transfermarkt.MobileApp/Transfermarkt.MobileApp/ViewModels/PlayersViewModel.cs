using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Xamarin.Forms;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class PlayersViewModel
    {
        private readonly APIService _apiServicePlayers = new APIService("Players");

        public PlayersViewModel() { }

        public ObservableCollection<PlayersClub> Players { get; set; } = new ObservableCollection<PlayersClub>();

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>((text) =>
                {
                    Search(text);
                }));
            }
        }
        public async Task Search(string text)
        {
            Players.Clear();
            var searchResult = await _apiServicePlayers.Get<List<Players>>(new PlayerSearchRequest
            {
                FirstName = text.ToLower(),
                LastName = text.ToLower()
            });
            foreach (var item in searchResult)
            {
                Players.Add(new PlayersClub
                {
                    Birthdate = item.Birthdate,
                    FirstName = item.FirstName,
                    Id = item.Id,
                    Jersey = item.Jersey,
                    LastName = item.LastName
                });
            }
        }
    }
}
