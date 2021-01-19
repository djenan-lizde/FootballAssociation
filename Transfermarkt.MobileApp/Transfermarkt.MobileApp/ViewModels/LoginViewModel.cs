using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Transfermarkt.MobileApp.Views;
using Transfermarkt.Models.Responses;
using Xamarin.Forms;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceUsers = new APIService("Users");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(() => Register());
        }

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public ICommand LoginCommand { get; set; }
        async Task Login()
        {
            try
            {
                var data = await _apiServiceUsers.Insert<UserAuthenticationResult>(new
                {
                    username = Username,
                    password = Password
                }, "login");

                if (data == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Information", "Wrong username or password", "OK");
                    return;
                }

                APIService.Token = data.Token;
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(ex.Message, "Wrong username or password", "OK");
            }
        }

        public ICommand RegisterCommand { get; set; }
        void Register()
        {
            Application.Current.MainPage = new RegisterPage();
        }
    }
}
