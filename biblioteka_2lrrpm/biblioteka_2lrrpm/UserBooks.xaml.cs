using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserBooks : ContentPage
    {
        protected internal ObservableCollection<Book> Books { get; set; }
        public UserBooks()
        {
            InitializeComponent();
            Books = new ObservableCollection<Book>
            {
                new Book {Name="Приключения Тома Сойера", Author="Марк Твен", Genre="Роман"},
                new Book {Name="Крокодил Гена и его друзья", Author="Эдуард Успенский", Genre="Фикшн"}
            };
            booklist.BindingContext = Books;
        }

        private async void booklist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book selectedBook = e.SelectedItem as Book;
            if (selectedBook != null)
            {
                booklist.SelectedItem = null;
                await Navigation.PushAsync(new Book1());
            }
        }
    }
}

