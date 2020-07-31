using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Transfermarkt.Models;
using Xamarin.Forms;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceUsers = new APIService("Users");

        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await Register());
        }

        public ICommand RegisterCommand { get; set; }

        async Task Register()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Email)
                    || string.IsNullOrEmpty(Password)
                    || string.IsNullOrEmpty(PasswordConfirmation)
                    || string.IsNullOrEmpty(FirstName)
                    || string.IsNullOrEmpty(LastName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "All fields are required", "OK");
                return;
            }
            var user = new UserRegistration
            {
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Password = Password,
                PasswordConfirmation = PasswordConfirmation,
                Username = Username,
                Roles = new List<int>()
            };
            user.Roles.Add(2);//represents a Member role

            await _apiServiceUsers.Insert<Users>(user, "Registration");
            await Application.Current.MainPage.DisplayAlert("Success", "Successful registration.", "OK");
            Application.Current.MainPage = new LoginPage();
        }

        public List<int> Roles { get; set; } = new List<int>();

        string _passwordconfirmation = string.Empty;
        public string PasswordConfirmation
        {
            get { return _passwordconfirmation; }
            set { SetProperty(ref _passwordconfirmation, value); }
        }

        string _lastname = string.Empty;
        public string LastName
        {
            get { return _lastname; }
            set { SetProperty(ref _lastname, value); }
        }

        string _firstname = string.Empty;
        public string FirstName
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
    }
}
