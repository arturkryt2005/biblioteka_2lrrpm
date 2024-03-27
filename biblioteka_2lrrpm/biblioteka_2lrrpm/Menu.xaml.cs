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
            InitializeComponent();

            if (theme == 'w')
            {
                this.BackgroundColor = Color.Pink;
            }
            else if (theme == 'b')
            {
                this.BackgroundColor = Color.Black;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Profile page = new Profile();
            await Navigation.PushAsync(page);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            UserBooks page = new UserBooks();
            await Navigation.PushAsync(page);
        }
        async void Ex(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            await Navigation.PushAsync(page);
        }

        private void OnThemeToggleClicked(object sender, EventArgs e)
        {
            Color currentColor = this.BackgroundColor;

            if (currentColor == Color.Black)
            {
                this.BackgroundColor = Color.Pink;
            }
            else
            {
                this.BackgroundColor = Color.Black;
            }
        }
    }
}
