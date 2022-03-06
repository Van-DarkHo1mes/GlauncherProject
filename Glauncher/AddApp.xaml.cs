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

namespace Glauncher
{

    public partial class AddApp : Window
    {

        string fileName = null;
        public static AddApp app;

        private void MovingWindow(object sender, RoutedEventArgs e)   //Метод для перемещения окна добавления на экране
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                AddApp.app.DragMove();
            }
        }

        public AddApp()
        {
            InitializeComponent();
            app = this;

        }

        private void CloseAddButton_Click(object sender, RoutedEventArgs e)  //Мето закрытия окна добавления
        {
            app.Close();
        }




        private void MenuItemApp_Click(object sender, RoutedEventArgs e)
        {
            TextBlockType.Text = "Приложение";
        }

        private void MenuItemGame_Click(object sender, RoutedEventArgs e)
        {
            TextBlockType.Text = "Игра";
        }

        private void MenuItemOther_Click(object sender, RoutedEventArgs e)
        {
            TextBlockType.Text = "Другое";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "EXE|*.exe",
                Multiselect = false,
                ValidateNames = true
            };
            if(fileDialog.ShowDialog() == true)
            {
                fileName = fileDialog.FileName;

                TextBlockFileName.Text ="...  "+fileName.Substring(fileName.LastIndexOf(@"\"));
            }

            

        }
    }
}
