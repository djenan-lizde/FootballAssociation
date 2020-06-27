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
    }
}