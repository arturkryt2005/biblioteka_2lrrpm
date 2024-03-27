using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage 
    {
        public Menu(char theme)
        {
            this.theme = theme;

            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Profile page = new Profile(theme);
            await Navigation.PushAsync(page);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            UserBooks page = new UserBooks(theme);
            await Navigation.PushAsync(page);
        }
        async void Ex(object sender, EventArgs e)
        {
            MainPage page = new MainPage(theme);
            await Navigation.PushAsync(page);
        }
    }
}
