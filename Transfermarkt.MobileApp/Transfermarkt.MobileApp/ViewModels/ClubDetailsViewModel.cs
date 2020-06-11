using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Xamarin.Forms;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class ClubDetailsViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceClubs = new APIService("Clubs");

        public ClubDetailsViewModel()
        {
            //InitCommand = new Command(() => Init());
        }

        public Club Club { get; set; }

        //ClubView clubView = new ClubView();

        //public void Init()
        //{
        //    clubView.Abbreviation = Club.Abbreviation;
        //    clubView.Founded = Club.Founded;
        //    clubView.Name = Club.Name;
        //    clubView.Nickname = Club.Nickname;
        //    clubView.MarketValue = Club.MarketValue;
        //}

        //public ICommand InitCommand { get; set; }
    }
}
