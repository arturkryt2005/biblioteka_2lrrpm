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
    public partial class BookPage : ContentPage
    {
        public char theme;

        bool edited = true; 
        public Book Book { get; set; }
        public BookPage(Book book, char theme)
        {
            InitializeComponent();

            Book = book;
            if (book == null)
            {
                Book = new Book();
                edited = false;
            }
            this.BindingContext = Book;

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

        async void SaveBook(object sender, EventArgs e)
        {
            if (nameEntry.Text != null && nameEntry.Text != "" && authorEntry.Text != null && authorEntry.Text != "" && genreEntry.Text != null && genreEntry.Text != "")
            {
                await Navigation.PopAsync();

                if (edited == false)
                {
                    NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
                    IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
                    MainBookPage homePage = navStack[navPage.Navigation.NavigationStack.Count - 1] as MainBookPage;
                }
            }
            else
            {
                await DisplayAlert("Ошибка", "Заполните все поля", "Ок");
            }
        }
    }
}
