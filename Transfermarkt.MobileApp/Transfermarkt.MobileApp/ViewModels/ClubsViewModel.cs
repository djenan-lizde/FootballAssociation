using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Xamarin.Forms;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class ClubsViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceClubs = new APIService("Clubs");
        private readonly APIService _apiServiceLeagues = new APIService("Leagues");

        public ClubsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        League _selectedLeague = null;
        public League SelectedLeague
        {
            get { return _selectedLeague; }
            set
            {
                SetProperty(ref _selectedLeague, value);
                InitCommand.Execute(null);
            }
        }

        public async Task Init()
        {
            if (LeaguesList.Count == 0)
            {
                var leagues = await _apiServiceLeagues.Get<List<League>>(null);
                foreach (var item in leagues)
                {
                    LeaguesList.Add(item);
                }
            }

            if (SelectedLeague != null)
            {
                //club points uraditi tip i onda ce se fixati sve
                var clubInLeague = await _apiServiceClubs.GetById<List<ClubLeague>>(SelectedLeague.Id, "ClubsInLeague");
                ClubsPoints.Clear();
                var counter = 0;
                foreach (var item in clubInLeague)
                {
                    var club = await _apiServiceClubs.GetById<Club>(item.ClubId);
                    var clubPoints = new ClubPoints
                    {
                        Id = club.Id,
                        Abbreviation = club.Abbreviation,
                        Logo = club.Logo,
                        Name = club.Name,
                        Points = item.Points,
                        Position = counter + 1
                    };
                    ClubsPoints.Add(clubPoints);
                }
            }
        }

        //public ObservableCollection<Club> ClubsList { get; set; } = new ObservableCollection<Club>();
        public ObservableCollection<ClubPoints> ClubsPoints { get; set; } = new ObservableCollection<ClubPoints>();
        public ObservableCollection<League> LeaguesList { get; set; } = new ObservableCollection<League>();

        public ICommand InitCommand { get; set; }
    }
}
