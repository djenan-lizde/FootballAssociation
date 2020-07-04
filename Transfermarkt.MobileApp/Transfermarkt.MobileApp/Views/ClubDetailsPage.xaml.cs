using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfermarkt.MobileApp.ViewModels;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Transfermarkt.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClubDetailsPage : ContentPage
    {
        private readonly ClubDetailsViewModel model = null;

        public ClubDetailsPage(ClubPoints club)
        {
            InitializeComponent();
            BindingContext = model = new ClubDetailsViewModel()
            {
                Club = club
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.ClubPlayers();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PlayersClub;

            await Navigation.PushAsync(new PlayerDetailsPage(item));
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MatchSchedulePage(model.Club.Id));
        }
    }
}