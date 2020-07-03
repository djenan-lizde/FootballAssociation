using Transfermarkt.MobileApp.ViewModels;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Transfermarkt.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchSchedulePage : ContentPage
    {
        private readonly MatchScheduleViewModel model = null;

        public MatchSchedulePage(int clubId)
        {
            InitializeComponent();
            BindingContext = model = new MatchScheduleViewModel()
            {
                ClubId = clubId
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MatchSchedule;

            await Navigation.PushAsync(new MatchDetailsPage(item));
        }
    }
}