using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Transfermarkt.Models.Requests;

namespace Transfermarkt.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayersPage : ContentPage
    {
        public PlayersPage()
        {
            InitializeComponent();
        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PlayersClub;

            await Navigation.PushAsync(new PlayerDetailsPage(item));
        }
    }

    public class TextChangedBehavior : Behavior<SearchBar>
    {
        protected override void OnAttachedTo(SearchBar bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        protected override void OnDetachingFrom(SearchBar bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((SearchBar)sender).SearchCommand?.Execute(e.NewTextValue);
        }
    }
}