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
        private string nameProg; //Имя файла
        private string fileName; //Имя(Путь) файла
        private string iconName;
        private string typeName;



        public static AddApp app; //ОбЬект текущего окна

        public AddApp()
        {
            InitializeComponent();
            app = this;

        }

        private void CloseAddButton_Click(object sender, RoutedEventArgs e)  //Метод закрытия окна добавления
        {
            app.Close();
        }

        private void MovingWindow(object sender, RoutedEventArgs e)   //Метод для перемещения окна добавления на экране
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                AddApp.app.DragMove();
            }
        }

        private void MenuItemApp_Click(object sender, RoutedEventArgs e) //Тип программы ПРИЛОЖЕНИЕ
        {
            TextBlockType.Text = "Приложение"; typeName = "appProgram";
        }

        private void MenuItemGame_Click(object sender, RoutedEventArgs e) //Тип программы ИГРА
        {
            TextBlockType.Text = "Игра"; typeName = "game";
        }

        private void MenuItemOther_Click(object sender, RoutedEventArgs e) //Тип программы ПРОГРАММА
        {
            TextBlockType.Text = "Другое"; typeName = "program";
        }

        private void IconButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "(*.JPEG;*.PNG)|*.jpg;*.png",
                Multiselect = false,
                ValidateNames = true
            };
            if (fileDialog.ShowDialog() == true)
            {
                iconName = fileDialog.FileName; //Полное имя пути файла

                TextBlockIconName.Text = "...  " + iconName.Substring(iconName.LastIndexOf(@"\"));
            }
        }

        private void FileButton_Click(object sender, RoutedEventArgs e) //Метод для получения полного пути программы
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "EXE|*.exe",
                Multiselect = false,
                ValidateNames = true
            };
            if(fileDialog.ShowDialog() == true)
            {
                fileName = fileDialog.FileName; //Полное имя пути файла

                TextBlockFileName.Text ="...  "+fileName.Substring(fileName.LastIndexOf(@"\"));
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //Собирает кнопку программы на странице "ВСЕ"
        {
            nameProg = AddName.Text;
            AllPage.NewProgramButton(nameProg, typeName, iconName, fileName);
            app.Close();
        }

        
    }
}
