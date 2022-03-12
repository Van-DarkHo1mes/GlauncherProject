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
using System.Diagnostics;

namespace Glauncher
{  
    
    public partial class AllPage : Page
    {

        public AllPage()
        {
            InitializeComponent();
            
            scrollfieldAll = scrollFieldAll;
            gridInfo = GridInfo;
            gridFon = GridFon;
        }

        private static List<Game> programGame = new List<Game>();
        private static List<Button> progButtons = new List<Button>();


        private static int indent = 0; //Поле отступа следующей кнопки
        private static int index = 0; //Поле проядка кнопок программ
        private static bool openIndexInfo = false;
        
        

        private static Grid scrollfieldAll; //Рабочее поле Grid куда добавляются кнопки
        private static Grid gridInfo; //Рабочее поле для информации и запуска приложений
        private static Grid gridFon; //Рабочее поле фона для информации и запуска приложений


        private static Style stylePlayButton = Application.Current.FindResource("playButton") as Style;
        private static Button playButton = new Button() //Кнопка запуска выбранной программы
        {
            Height = 40,
            Width = 120,
            Content = "ЗАПУСК",
            Style = stylePlayButton,
            
        };




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
            programbtn.Click += Programbtn_Click;
            progButtons.Add(programbtn);

            scrollfieldAll.Children.Add(programbtn); // Вывод на рабочее поле
            scrollfieldAll.Children.Add(imageBorder);
            scrollfieldAll.Children.Add(textBlockName);


            if (typeName == "game")
            {
               Game game = new Game(index, indent, nameProg, fileName, typeName, iconName);
               programGame.Add(game);
            }

            indent += 80; //Переменная отступа
            index += 1;
        }



        private static void Programbtn_Click(object sender, RoutedEventArgs e) //Метод создания окна информации
        {
            var buttonProg = (FrameworkElement)sender;

            TextBlock nameTextBlock = new TextBlock()
            {
                Background = Brushes.Transparent,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(50, 110, 0, 0),
                FontFamily = new FontFamily("Calibri"),
                FontSize = 20,
            };


            if (openIndexInfo == false)
            {
                Border borderFon = new Border()
                {
                    Background = Brushes.Black,
                    CornerRadius = new CornerRadius(12),
                    BorderBrush = Brushes.White,
                    BorderThickness = new Thickness(1)
                };

                ImageBrush ibr = new ImageBrush(); //Дефолтный фон окна информации программы
                ibr.ImageSource = new BitmapImage(
                    new Uri(@"C:\Users\super\Pictures\Saved Pictures\BIF.jpg")
                );
                Border borderImageFon = new Border()
                {
                    Height = 100,
                    Width = 393,
                    Background = ibr,
                    BorderBrush = Brushes.White,
                    BorderThickness = new Thickness(1),
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    CornerRadius = new CornerRadius(12, 12, 0, 0)
                };



                Style styleAddFonButton = Application.Current.FindResource("addFonButton") as Style; //Кнопка выбора фона
                Button addFonButton = new Button()
                {
                    Height = 30,
                    Width = 250,
                    Style = styleAddFonButton,
                    BorderThickness = new Thickness(0),
                    Content = "Вы можете добавить свой фон",
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 15, 0, 0)
                };

                playButton.Margin = new Thickness(0, 0, 0, 20);
                playButton.VerticalAlignment = VerticalAlignment.Bottom;
                playButton.HorizontalAlignment = HorizontalAlignment.Center;
                playButton.Click += playButton_Click;

                gridFon.Children.Add(borderFon);
                gridFon.Children.Add(borderImageFon);
                gridFon.Children.Add(addFonButton);
                gridFon.Children.Add(playButton);

                openIndexInfo = true;
            }
            else
            {
                gridInfo.Children.Clear();
            }

            int i = 0;
            int indexProg = 0;
            foreach (var button in progButtons)
            {
                if (buttonProg == button)
                {
                    indexProg = i;
                }
                i++;
            }
            nameTextBlock.Text = programGame[indexProg].Name;
            
            gridInfo.Children.Add(nameTextBlock);



        }

        private static void playButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(programGame[index].FileName);
        }

    }
}
