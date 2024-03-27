using System;
using Xamarin.Forms;

namespace biblioteka_2lrrpm
{
    public partial class MainPage : ContentPage
    {
        public char theme;

        public MainPage(char theme)
        {
            InitializeComponent();

            this.theme = theme;
        }
        private void OnRoleSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRole = Pick.SelectedItem as string;
            SelectedRoleLabel.Text = $"Выбранная роль: {selectedRole}";
        }

        private void OnThemeToggleClicked(object sender, EventArgs e)
        {
            Color currentColor = this.BackgroundColor;

            if (currentColor == Color.Black)
            {
                this.BackgroundColor = Color.Pink;
                this.theme = 'w';
            }
            else
            {
                this.BackgroundColor = Color.Black;
                this.theme = 'b';
            }
        }

        private void OnBirthDateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime selectedDate = e.NewDate;
            SelectedDateLabel.Text = $"Выбранная дата: {selectedDate.ToString("dd/MM/yyyy")}";
        }

        private void OnSecondBirthDateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime selectedDate = e.NewDate;
            DateTime currentDate = DateTime.Now;
            DateTime minDate = currentDate.AddYears(-100);

            if (selectedDate > minDate || selectedDate > DateTime.Now)
            {
                SelectedDateLabel.Text = $"Выбранная дата: {selectedDate.ToString("dd/MM/yyyy")}";
            }
            else
            {
                DisplayAlert("Ошибка", "Введите корректную дату", "OK");
                BirthDatePicker.Date = minDate;
            }
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string login = Log.Text;
            string password = Pas.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Ошибка", "Введите логин и пароль", "OK");
                return; 
            }
            if (Pick.SelectedIndex == 0)
            {
                Menu page = new Menu(theme);
                await Navigation.PushAsync(page);
            }
            if (Pick.SelectedIndex == 1)
            {
                Menu1 page = new Menu1(theme);
                await Navigation.PushAsync(page);
            }
            if (Pick.SelectedIndex == 2)
            {
                Menu2 page = new Menu2(theme);
                await Navigation.PushAsync(page);
            }


        }
    }
}
