using System;
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
        bool edited = true; 
        public User User { get; set; }
        public UserPage(User user)
        {
            InitializeComponent();
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

                if (edited == false)
                {
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

