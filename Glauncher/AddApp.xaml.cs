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

namespace Glauncher
{

    public partial class AddApp : Window
    {
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

    }
}
