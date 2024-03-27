﻿using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainUserPage : ContentPage
    {
        protected internal ObservableCollection <User> Users { get; set; }
        public User User { get; set; }
        public MainUserPage()
        {
            InitializeComponent();
            Users = new ObservableCollection<User>
            {
                new User {Login="artur", Password="bakasov"},
            };
            userlist.BindingContext = Users;
        }

        private async void userlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            User selectedUser = e.SelectedItem as User;
            if (selectedUser != null)
            {
                // Снимаем выделение
                userlist.SelectedItem = null;
                // Переходим на страницу редактирования элемента 
                await Navigation.PushAsync(new UserPage(selectedUser));
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserPage(null));
        }
        protected internal void AddUser(User user)
        {
            Users.Add(user);
        }
        async void Ex(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            await Navigation.PushAsync(page);
        }
    }
}