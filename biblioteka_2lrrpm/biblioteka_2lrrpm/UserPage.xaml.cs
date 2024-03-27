﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public char theme;

        bool edited = true; // флаг редактирования
        public User User { get; set; }
        public UserPage(User user, char theme)
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

            User = user;
            if (user == null)
            {
                User = new User();
                edited = false;
            }
            this.BindingContext = User;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (loginEntry.Text != null && loginEntry.Text != "" && passwordEntry.Text != null && passwordEntry.Text != "")
            {
                await Navigation.PopAsync();

                // если добавление
                if (edited == false)
                {
                    // находим в стеке предпоследнюю страницу - то есть MainPage
                    NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
                    IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
                    MainUserPage homePage = navStack[navPage.Navigation.NavigationStack.Count - 1] as MainUserPage;

                    if (homePage != null)
                    {
                        homePage.AddUser(User);
                    }
                }
            }
            else
            {
                await DisplayAlert("Ошибка", "Заполните все поля", "Ок");
            }
        }
    }
}

