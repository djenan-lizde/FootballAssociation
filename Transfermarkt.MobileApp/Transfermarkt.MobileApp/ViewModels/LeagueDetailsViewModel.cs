using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Xamarin.Forms;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class LeagueDetailsViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceClubs = new APIService("Clubs");
        private readonly APIService _apiServiceSeasons = new APIService("Seasons");


        public LeagueDetailsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public Leagues selectedLeague;

        Seasons _selectedSeason = null;
        public Seasons SelectedSeason
        {
            get { return _selectedSeason; }
            set
            {
                SetProperty(ref _selectedSeason, value);
                InitCommand.Execute(null);
            }
        }

        public ObservableCollection<ClubPoints> ClubsList { get; set; } = new ObservableCollection<ClubPoints>();
        public ObservableCollection<Seasons> SeasonsList { get; set; } = new ObservableCollection<Seasons>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var seasons = await _apiServiceSeasons.Get<List<Seasons>>(null);
            if (seasons.Count > 0)
            {
                foreach (var item in seasons)
                {
                    SeasonsList.Add(item);
                }
            }

            if (SelectedSeason != null)
            {
                var clubLeague = await _apiServiceClubs.GetById<List<ClubsLeague>>(selectedLeague.Id, "ClubsInLeague");
                if (clubLeague.Count > 0)
                {
                    int counter = 1;
                    foreach (var item in clubLeague.Where(x => x.SeasonId == SelectedSeason.Id).OrderByDescending(x => x.Points))
                    {
                        var club = await _apiServiceClubs.GetById<Clubs>(item.ClubId);
                        if (club != null)
                        {
                            ClubsList.Add(new ClubPoints
                            {
                                Points = item.Points,
                                Id = club.Id,
                                Logo = club.Logo,
                                Name = club.Name,
                                Abbreviation = club.Abbreviation,
                                Position = counter
                            });
                        }
                        counter += 1;
                    }
                }
            }
        }
    }
}
