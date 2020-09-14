using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Transfermarkt.MobileApp.Models;

namespace Transfermarkt.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Clubs, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Clubs:
                        MenuPages.Add(id, new NavigationPage(new ClubsPage()));
                        break;
                    case (int)MenuItemType.Leagues:
                        MenuPages.Add(id, new NavigationPage(new LeaguesPage()));
                        break;
                    case (int)MenuItemType.Players:
                        MenuPages.Add(id, new NavigationPage(new PlayersPage()));
                        break;
                    case (int)MenuItemType.Matches:
                        MenuPages.Add(id, new NavigationPage(new MatchesPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}