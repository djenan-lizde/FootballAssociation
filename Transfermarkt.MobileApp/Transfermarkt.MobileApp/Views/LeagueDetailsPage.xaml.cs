using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfermarkt.MobileApp.ViewModels;
using Transfermarkt.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Transfermarkt.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeagueDetailsPage : ContentPage
    {
        private readonly LeagueDetailsViewModel model = null;
        public LeagueDetailsPage(League league)
        {
            InitializeComponent();
            BindingContext = model = new LeagueDetailsViewModel()
            {
                selectedLeague = league
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await model.Init();
        }
    }
}