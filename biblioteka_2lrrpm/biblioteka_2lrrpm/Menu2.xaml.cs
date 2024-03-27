using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu2 : ContentPage
    {
        public char theme;

        public Menu2(char theme)
        {
            InitializeComponent();

            this.theme = theme;

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
            MainUserPage user = new MainUserPage(theme);
            await Navigation.PushAsync(user);
        }

        async void Ex(object sender, EventArgs e)
        {
            MainPage page = new MainPage(theme);
            await Navigation.PushAsync(page);
        }
    }
}

