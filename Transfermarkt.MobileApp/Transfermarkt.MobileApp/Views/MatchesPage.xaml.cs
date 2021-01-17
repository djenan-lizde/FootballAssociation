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
    public partial class MatchesPage : ContentPage
    {
        private readonly MatchesViewModel model = null;

        public MatchesPage()
        {
            InitializeComponent();
            BindingContext = model = new MatchesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MatchesView;

            var match = new MatchSchedule
            {
                Id = item.Id,
                GameStart = $"{item.GameDate:MM/dd/yyyy} + {item.GameStart}",
                MatchGame = $"{item.HomeClub} {item.AwayClub}"
            };

            await Navigation.PushAsync(new MatchDetailsPage(match));
        }
    }
}