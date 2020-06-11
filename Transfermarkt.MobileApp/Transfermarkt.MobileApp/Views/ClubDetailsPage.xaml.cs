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
    public partial class ClubDetailsPage : ContentPage
    {
        private readonly ClubDetailsViewModel model = null;

        public ClubDetailsPage(Club club)
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
            //model.Init();
        }
    }
}