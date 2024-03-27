using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public char theme;
        public string LoginWalk, PassWalk;

        public Profile(char theme, string LoginWalk, string PassWalk)
        {
            InitializeComponent();

            this.theme = theme;
            this.LoginWalk = LoginWalk;
            this.PassWalk = PassWalk;

            if (theme == 'w')
            {
                this.BackgroundColor = Color.Pink;
            }
            else if (theme == 'b')
            {
                this.BackgroundColor = Color.Black;
            }
        }

        async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                // выбираем фото
                var photo = await MediaPicker.PickPhotoAsync();
                // проверяем, что выбранное фото не является пустым
                if (photo != null)
                {
                    // загружаем в ImageView
                    img.Source = ImageSource.FromFile(photo.FullPath);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка!", ex.Message, "OK");
            }
        }
        async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                // для примера сохраняем файл в локальном хранилище
                var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                // загружаем в ImageView
                img.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка!", ex.Message, "OK");
            }
        }
        async void Ex(object sender, EventArgs e)
        {
            MainPage page = new MainPage(theme);
            await Navigation.PushAsync(page);
        }

        public string LoginReturn(object sender, EventArgs e)
        {
            return this.LoginWalk;
        }

        public string PasswordReturn(object sender, EventArgs e)
        {
            return this.PassWalk;
        }
    }

}

