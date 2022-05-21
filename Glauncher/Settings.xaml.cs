using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Diagnostics;

namespace Glauncher
{
    
    public partial class Settings : Window
    {
        public static Settings settings;
        private static string newIconName;

        public Settings()
        {
            InitializeComponent();
            settings = this;
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e) //Закрытые окна
        {
            settings.Close();
        }

        private void NewIconButton_Click(object sender, RoutedEventArgs e) //Кнопка изменения иконки
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "(*.JPEG;*.PNG)|*.jpg;*.png",
                Multiselect = false,
                ValidateNames = true
            };
            if (fileDialog.ShowDialog() == true)
            {
                newIconName = fileDialog.FileName; //Полное имя пути файла

                NewIcon.Text = "...  " + newIconName.Substring(newIconName.LastIndexOf(@"\"));
            }

        }

        private void FileButton_Click(object sender, RoutedEventArgs e) //Вызывает метод просмотра файлов папки где находится exe'шник
        {
            AllPage.OpenFile();
        }

        private void RenameButton_Click(object sender, RoutedEventArgs e) //Вызывает метод ренейма кнопки
        {

            AllPage.RenameInfoProg(NewName.Text, newIconName);

            settings.Close();
        }

    }
}
