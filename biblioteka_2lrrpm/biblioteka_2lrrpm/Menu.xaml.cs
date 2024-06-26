﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage 
    {
        public char theme;
        public string LoginWalk, PassWalk;

        public Menu(char theme, string LoginWalk, string PassWalk)
        {
            this.theme = theme;
            this.LoginWalk = LoginWalk;
            this.PassWalk = PassWalk;

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
            Profile page = new Profile(theme, LoginWalk, PassWalk);
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
