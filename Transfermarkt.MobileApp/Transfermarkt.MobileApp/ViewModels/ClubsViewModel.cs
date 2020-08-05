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

        Leagues _selectedLeague = null;
        public Leagues SelectedLeague
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
                var leagues = await _apiServiceLeagues.Get<List<Leagues>>(null);
                if (leagues.Count > 0)
                {
                    foreach (var item in leagues)
                    {
                        LeaguesList.Add(item);
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Information", "We don't have leagues.", "OK");
                }
            }

            if (SelectedLeague != null)
            {
                var clubInLeague = await _apiServiceClubs.GetById<List<ClubsLeague>>(SelectedLeague.Id, "ClubsInLeague");
                if (clubInLeague.Count > 0)
                {
                    ClubsPoints.Clear();
                    var counter = 0;
                    foreach (var item in clubInLeague)
                    {
                        var club = await _apiServiceClubs.GetById<Clubs>(item.ClubId);
                        if (club != null)
                        {
                            ClubsPoints.Add(new ClubPoints
                            {
                                Id = club.Id,
                                Abbreviation = club.Abbreviation,
                                Logo = club.Logo,
                                Name = club.Name,
                                Points = item.Points,
                                Position = counter + 1
                            });
                        }
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Information", "We don't have clubs in leagues", "OK");
                }
            }
        }

        public ObservableCollection<ClubPoints> ClubsPoints { get; set; } = new ObservableCollection<ClubPoints>();
        public ObservableCollection<Leagues> LeaguesList { get; set; } = new ObservableCollection<Leagues>();

        public ICommand InitCommand { get; set; }
    }
}
