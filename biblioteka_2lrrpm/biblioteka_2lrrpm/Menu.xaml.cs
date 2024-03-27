﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage 
    {
        public char theme;

        public Menu(char theme)
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
