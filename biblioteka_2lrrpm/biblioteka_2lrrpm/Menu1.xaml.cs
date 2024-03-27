using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu1 : ContentPage
    {
        public char theme;

        public Menu1(char theme)
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
            MainBookPage book = new MainBookPage(theme);
            await Navigation.PushAsync(book);
        }
        async void Ex(object sender, EventArgs e)
        {
            MainPage page = new MainPage(theme);
            await Navigation.PushAsync(page);
        }
    }
}
