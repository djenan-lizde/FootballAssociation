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
        }

        public Club Club { get; set; }

    }
}
