﻿using System;
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
    public partial class PlayerDetailsPage : ContentPage
    {
        private readonly PlayerDetailsViewModel model = null;

        public PlayerDetailsPage(PlayersClub player)
        {
            InitializeComponent();
            BindingContext = model = new PlayerDetailsViewModel()
            {
                Player = player
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.PlayerContracts();
        }
    }
}