using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Transfermarkt.MobileApp.Services;
using Transfermarkt.MobileApp.Views;
using Transfermarkt.MobileApp.ViewModels;

namespace Transfermarkt.MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
