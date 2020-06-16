using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

        public LeagueDetailsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public League selectedLeague;

        Season _selectedSeason = null;
        public Season SelectedSeason
        {
            get { return _selectedSeason; }
            set
            {
                SetProperty(ref _selectedSeason, value);
                InitCommand.Execute(null);
            }
        }

        public ObservableCollection<ClubPoints> ClubsList { get; set; } = new ObservableCollection<ClubPoints>();
        public ObservableCollection<Season> SeasonsList { get; set; } = new ObservableCollection<Season>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var seasons = await _apiServiceClubs.Get<List<Season>>(null, "AllSeasons");
            var counter = 0;

            foreach (var item in seasons)
            {
                SeasonsList.Add(item);
            }

            if (SelectedSeason != null)
            {
                var clubLeague = await _apiServiceClubs.GetById<List<ClubLeague>>(selectedLeague.Id, "ClubsInLeague");

                foreach (var item in clubLeague.Where(x => x.SeasonId == SelectedSeason.Id).OrderByDescending(x => x.Points))
                {
                    var club = await _apiServiceClubs.GetById<Club>(item.ClubId);
                    var clubPoint = new ClubPoints
                    {
                        Points = item.Points,
                        Id = club.Id,
                        Logo = club.Logo,
                        Name = club.Name,
                        Abbreviation = club.Abbreviation,
                        Position = counter += 1
                    };
                    ClubsList.Add(clubPoint);
                }
            }
        }
    }
}
