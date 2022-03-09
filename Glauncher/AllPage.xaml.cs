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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Glauncher
{  
    public partial class AllPage : Page
    {

        public AllPage()
        {
            InitializeComponent();
            scrollfieldAll = scrollFieldAll;
            
        }

        private static int indent = 0; //Поле отступа следующей кнопки
        private static int index = 0; //Поле проядка кнопок программ
        

        private static Grid scrollfieldAll; //Рабочее поле Grid куда добавляются кнопки

        public static void NewProgramButton(string nameProg, string typeName, string iconName, string fileName) //Собирает Программную кнопку на странице ВСЕ
        {

            ImageBrush ib = new ImageBrush(); //Изображение на кнопке
            ib.ImageSource = new BitmapImage(
                new Uri(iconName) //Путь к изображению
                );
            Border imageBorder = new Border()
            {
                Height = 50,
                Width = 50,
                Margin = new Thickness(30, indent + 10, 0, 0),
                Background = ib,
                CornerRadius = new CornerRadius(25),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.White
            };

            TextBlock textBlockName = new TextBlock() //Название кнопки
            { 
                Foreground = Brushes.White,
                FontSize = 20,
                FontFamily = new FontFamily("Calibri"),
                Margin = new Thickness(95, indent + 22, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
            };
            textBlockName.Text = nameProg; //Имя добавляемой программы

            Style style = Application.Current.FindResource("menuButtonStyle") as Style; //Сама кнопка
            Button programbtn = new Button();
            programbtn.Style = style;  
            programbtn.Margin = new Thickness(20, indent, 0, 0);

            scrollfieldAll.Children.Add(programbtn); // Вывод на рабочее поле
            scrollfieldAll.Children.Add(imageBorder);
            scrollfieldAll.Children.Add(textBlockName);

            if (typeName == "game")
            {
               Game game = new Game(index, indent, nameProg, fileName, typeName, iconName);
            }

            indent += 80; //Переменная отступа
            index += 1;
        }

        

    }
}
