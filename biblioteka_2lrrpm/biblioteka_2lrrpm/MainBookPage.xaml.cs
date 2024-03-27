using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainBookPage : ContentPage
    {
        public char theme;

        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public MainBookPage(char theme)
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateFileList();
        }
        async void Save(object sender, EventArgs args)
        {
            string filename = fileNameEntry.Text;
            if (String.IsNullOrEmpty(filename)) return;
            if (File.Exists(Path.Combine(folderPath, filename)))
            {
                bool isRewrited = await DisplayAlert("Ошибка", "Книга уже существует, перезаписать её?", "Да", "Нет");
                if (isRewrited == false) return;
            }
            File.WriteAllText(Path.Combine(folderPath, filename), textEditor.Text);
            UpdateFileList();
        }
        void FileSelect(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem == null) return;
            string filename = (string)args.SelectedItem;
            textEditor.Text = File.ReadAllText(Path.Combine(folderPath, (string)args.SelectedItem));
            fileNameEntry.Text = filename;
            filesList.SelectedItem = null;

        }
        void Delete(object sender, EventArgs args)
        {
            string filename = (string)((MenuItem)sender).BindingContext;
            File.Delete(Path.Combine(folderPath, filename));
            UpdateFileList();
        }
        void UpdateFileList()
        {
            filesList.ItemsSource = Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f));
            filesList.SelectedItem = null;
        }
        async void Ex(object sender, EventArgs e)
        {
            Menu1 page = new Menu1(theme);
            await Navigation.PushAsync(page);
        }
    }

}

