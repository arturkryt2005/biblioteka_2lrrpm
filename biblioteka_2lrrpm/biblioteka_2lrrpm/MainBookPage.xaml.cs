﻿using System;
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
        // сохранение текста в файл
        async void Save(object sender, EventArgs args)
        {
            string filename = fileNameEntry.Text;
            if (String.IsNullOrEmpty(filename)) return;
            // если файл существует
            if (File.Exists(Path.Combine(folderPath, filename)))
            {
                // запрашиваем разрешение на перезапись
                bool isRewrited = await DisplayAlert("Ошибка", "Книга уже существует, перезаписать её?", "Да", "Нет");
                if (isRewrited == false) return;
            }
            // перезаписываем файл
            File.WriteAllText(Path.Combine(folderPath, filename), textEditor.Text);
            // обновляем список файлов
            UpdateFileList();
        }
        void FileSelect(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem == null) return;
            // получаем выделенный элемент
            string filename = (string)args.SelectedItem;
            // загружем текст в текстовое поле
            textEditor.Text = File.ReadAllText(Path.Combine(folderPath, (string)args.SelectedItem));
            // устанавливаем название файла
            fileNameEntry.Text = filename;
            // снимаем выделение
            filesList.SelectedItem = null;

        }
        void Delete(object sender, EventArgs args)
        {
            // получаем имя файла
            string filename = (string)((MenuItem)sender).BindingContext;
            // удаляем файл из списка
            File.Delete(Path.Combine(folderPath, filename));
            // обновляем список файлов
            UpdateFileList();
        }
        // обновление списка файлов
        void UpdateFileList()
        {
            // получаем все файлы
            filesList.ItemsSource = Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f));
            // снимаем выделение
            filesList.SelectedItem = null;
        }
        async void Ex(object sender, EventArgs e)
        {
            Menu1 page = new Menu1(theme);
            await Navigation.PushAsync(page);
        }
    }

}

