using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfermarkt.MobileApp.ViewModels;
using Transfermarkt.Models.Requests;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Transfermarkt.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchDetailsPage : ContentPage
    {
        private readonly MatchDetailsViewModel model = null;

        public MatchDetailsPage(MatchSchedule matchSchedule)
        {
            InitializeComponent();
            BindingContext = model = new MatchDetailsViewModel()
            {
                Match = matchSchedule
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}