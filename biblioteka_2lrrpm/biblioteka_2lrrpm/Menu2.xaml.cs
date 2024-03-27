using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu2 : ContentPage
    {
        public Menu2()
        {
            InitializeComponent();
        }

        private void OnThemeToggleClicked2(object sender, EventArgs e)
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            MainUserPage user = new MainUserPage();
            await Navigation.PushAsync(user);
        }
        async void Ex(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            await Navigation.PushAsync(page);
        }
    }
}

