using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    public partial class App : Application
    {
        public char theme;

        public App(char theme)
        {
            InitializeComponent();

            this.theme = theme;

            MainPage = new NavigationPage(new MainPage(theme));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
