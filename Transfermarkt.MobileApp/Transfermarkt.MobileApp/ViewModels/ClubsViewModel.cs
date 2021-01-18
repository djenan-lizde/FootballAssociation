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
        private readonly APIService _apiServiceMatches = new APIService("Matches");

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

        string recommendedMatch = string.Empty;
        public string RecommendedMatch
        {
            get { return recommendedMatch; }
            set { SetProperty(ref recommendedMatch, value); }
        }

        public async Task Init()
        {
            try
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
                        var match = await _apiServiceMatches.GetById<Matches>(SelectedLeague.Id, "RecommendMatch");

                        if (match == null)
                        {
                            await Application.Current.MainPage.DisplayAlert("Information", "Season is not created yet.", "OK");
                            return;
                        }
                        var homeClub = await _apiServiceClubs.GetById<Clubs>(match.HomeClubId);
                        var awayClub = await _apiServiceClubs.GetById<Clubs>(match.AwayClubId);
                        RecommendedMatch = $"{homeClub.Name} vs {awayClub.Name} - {match.DateGame:dddd, dd MMMM yyyy} {match.GameStart}";
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "We don't have clubs in leagues", "OK");
                    }
                }
            }
            catch (System.Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Information", "Error", "OK");
                return;
                throw;
            }
        }

        public ObservableCollection<ClubPoints> ClubsPoints { get; set; } = new ObservableCollection<ClubPoints>();
        public ObservableCollection<Leagues> LeaguesList { get; set; } = new ObservableCollection<Leagues>();

        public ICommand InitCommand { get; set; }
    }
}
