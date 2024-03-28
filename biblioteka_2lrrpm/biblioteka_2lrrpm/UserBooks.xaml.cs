using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserBooks : ContentPage
    {
        public char theme;

        protected internal ObservableCollection<Book> Books { get; set; }
        public UserBooks(char theme)
        {
            InitializeComponent();
            Books = new ObservableCollection<Book>
            {
                new Book {Name="Приключения Тома Сойера", Author="Марк Твен", Genre="Роман"},
                new Book {Name="Крокодил Гена и его друзья", Author="Эдуард Успенский", Genre="Фикшн"}
            };
            this.BindingContext = Books;

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

        private async void booklist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book selectedBook = e.SelectedItem as Book;
            if (selectedBook != null)
            {
                await Navigation.PushAsync(new Book1(theme));
            }
        }
    }
}

