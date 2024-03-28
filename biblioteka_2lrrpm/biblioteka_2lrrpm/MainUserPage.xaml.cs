using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainUserPage : ContentPage
    {
        public char theme;

        protected internal ObservableCollection <User> Users { get; set; }
        public User User { get; set; }
        public MainUserPage(char theme)
        {
            InitializeComponent();
            Users = new ObservableCollection<User>
            {
                new User {Login="artur", Password="bakasov"},
            };
            userlist.BindingContext = Users;

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

        private async void userlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            User selectedUser = e.SelectedItem as User;
            if (selectedUser != null)
            {
                userlist.SelectedItem = null;
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
            MainPage page = new MainPage(theme);
            await Navigation.PushAsync(page);
        }
    }
}
