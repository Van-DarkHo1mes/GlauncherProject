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
using Microsoft.Win32;

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

        

        private static List<Program> programAll = new List<Program>(); //Лист всех программ
        private static List<Button> progButtons = new List<Button>(); //Лист всех кнопок
        private static List<Panel> gridButtons = new List<Panel>(); //Лист всех контейнеров кнопок

        private static FrameworkElement buttonProg;

        private static int indexProg = 0; //Индек активной программы
        private static int indent = 0; //Поле отступа следующей кнопки
        public static int IndexAll { get; set; } //Поле проядка кнопок программ
        private static bool openIndexInfo = false; //Флаг открытия окна информации
        private static string defoltFon = System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().LastIndexOf("Glauncher") + 10) + "BIF.jpg";





        private static Grid scrollfieldAll; //Рабочее поле Grid куда добавляются кнопки
        private static Grid gridInfo; //Рабочее поле для информации и запуска приложений
        private static Grid gridFon; //Рабочее поле фона для информации и запуска приложений
        


        private static Style stylePlayButton = Application.Current.FindResource("playButton") as Style;
        private static Button playButton = new Button() //Кнопка запуска выбранной программы
        {
            Height = 40,
            Width = 150,
            Content = "ЗАПУСК",
            Style = stylePlayButton,
            Margin = new Thickness(0, 0, 0, 20),
            VerticalAlignment = VerticalAlignment.Bottom,
            HorizontalAlignment = HorizontalAlignment.Center,
        };

        private static Border iconBorderFon = new Border() //Иконка на окне информации
        {
            Height = 80,
            Width = 80,
            Margin = new Thickness(20, 60, 0, 0),
            CornerRadius = new CornerRadius(40),
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            BorderThickness = new Thickness(1),
            BorderBrush = Brushes.White
        };

        private static TextBlock nameTextBlock = new TextBlock() //ТекстБлок для названия программы на окне информации
        {
            Background = Brushes.Transparent,
            Foreground = Brushes.White,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(110, 105, 0, 0),
            FontFamily = new FontFamily("Roboto Medium"),
            FontSize = 28,
        };

        private static Style styleSettingsButton = Application.Current.FindResource("SettingsButton") as Style; //Кнопка настроек
        private static Button settingsButton = new Button()
        {
            Style = styleSettingsButton,
            Margin = new Thickness(320, 0, 0, 20),
            VerticalAlignment = VerticalAlignment.Bottom,
            HorizontalAlignment = HorizontalAlignment.Center,
            
        };

        private static Border borderImageFon = new Border()
        {
            Height = 100,
            Width = 393,
            BorderBrush = Brushes.White,
            BorderThickness = new Thickness(1),
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Center,
            CornerRadius = new CornerRadius(12, 12, 0, 0),
            
        };

        private static Style styleAddFonButton = Application.Current.FindResource("addFonButton") as Style; //Кнопка выбора фона
        private static Button addFonButton = new Button()
        {
            Height = 30,
            Style = styleAddFonButton,
            BorderThickness = new Thickness(0),
            Content = "Вы можете добавить свой фон",
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Center,
            Margin = new Thickness(0, 15, 0, 0),

        };



        public static void NewProgramButton(string nameProg, string typeName, string iconName, string fileName) //Собирает Программную кнопку на странице ВСЕ
        {

            Grid buttonGrid = new Grid()
            {
                Height = 70,
                Width = 300,
                Margin = new Thickness(0, indent, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            ImageBrush ib = new ImageBrush(); //Изображение на кнопке
            ib.ImageSource = new BitmapImage(
                new Uri(iconName) //Путь к изображению
                );

            Border imageBorder = new Border()
            {
                Height = 50,
                Width = 50,
                Margin = new Thickness(10, 0, 0, 0),
                CornerRadius = new CornerRadius(25),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.White
            };
            ib.Stretch = Stretch.UniformToFill;
            imageBorder.Background = ib;

            TextBlock textBlockName = new TextBlock() //Название кнопки
            {
                Foreground = Brushes.White,
                FontSize = 20,
                FontFamily = new FontFamily("Roboto Medium"),
                Margin = new Thickness(75, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
            };
            textBlockName.Text = nameProg; //Имя добавляемой программы

            Style styleProgramBTN = Application.Current.FindResource("menuButtonStyle") as Style; //Сама кнопка
            Button programbtn = new Button()
            {
            Style = styleProgramBTN,
            };
            programbtn.Click += Programbtn_Click;
            progButtons.Add(programbtn);


            buttonGrid.Children.Add(programbtn); //Контейнер элементов кнопки
            buttonGrid.Children.Add(imageBorder);
            buttonGrid.Children.Add(textBlockName);

            gridButtons.Add(buttonGrid);
            scrollfieldAll.Children.Add(buttonGrid); // Вывод на рабочее поле

            if (typeName == "game")
            {
                Game game = new Game(IndexAll, 1,/* .IndexGame,*/indent, nameProg, fileName, typeName, iconName, defoltFon);
                programAll.Add(game);
            }
            if (typeName == "appProgram")
            {
                AppProgram appProgram = new AppProgram(IndexAll, AppPage.IndexApp, indent, nameProg, fileName, iconName, iconName, defoltFon);
                programAll.Add(appProgram);
            }

            indent += 80; //Переменная отступа
        }



        private static void Programbtn_Click(object sender, RoutedEventArgs e) //Метод создания окна информации
        {
            buttonProg = (FrameworkElement)sender;




            if (openIndexInfo == false) //Создает фон окна информации
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
                    new Uri(defoltFon)
                );


                
                borderImageFon.Background = ibr;

                gridFon.Children.Add(borderFon);
                

                openIndexInfo = true;
            }
            else //Удаляет всю информацию с окна информации
            {
                gridInfo.Children.Clear();
            }


            //Добавление на окно информации
            int i = 0;


            foreach (var button in progButtons) //Ищет и сравнивает нажатую кнопку 
            {
                if (buttonProg == button)
                {
                    indexProg = i;
                    break;
                }
                i++;
            }
            nameTextBlock.Text = programAll[indexProg].Name;
            playButton.Click += (o, e) => playButton_Click(o, e, indexProg);

            ImageBrush ib = new ImageBrush(); //Изображение на окне информации
            ib.ImageSource = new BitmapImage(
                new Uri(programAll[indexProg].ImageIcon)
                );
            ib.Stretch = Stretch.UniformToFill;
            iconBorderFon.Background = ib;

            settingsButton.Click += (o, e) => SettingsButton_Click(o, e, indexProg);

            ImageBrush ibf = new ImageBrush();
            ibf.Stretch = Stretch.Fill;
            ibf.ImageSource = new BitmapImage(
                new Uri(programAll[indexProg].ImageFon)
                );



            borderImageFon.Background = ibf;

            addFonButton.Click += AddFonButton_Click;


            
            gridInfo.Children.Add(nameTextBlock);
            gridInfo.Children.Add(playButton);
            gridInfo.Children.Add(settingsButton);
            gridInfo.Children.Add(borderImageFon);
            gridInfo.Children.Add(addFonButton);
            gridInfo.Children.Add(iconBorderFon);

        }

        private static void SettingsButton_Click(object o, RoutedEventArgs e, int indexProg) //Открывает окно настроек
        {
            Settings settings = new Settings();
            settings.ShowDialog();
            
        }



        private static void playButton_Click(object sender, RoutedEventArgs e, int indexProg) //Запускает или закрывает программу
        {
            Process.Start(programAll[indexProg].FileName);
        }


        public static void OpenFile() //Просмотр файлов в окне настроек
        {
            Process.Start("explorer.exe", programAll[indexProg].FileName.Substring(0, programAll[indexProg].FileName.LastIndexOf(@"\") + 1));
           
        }


        public static void RenameInfoProg(string newName, string newIcon) //Измение имени и/или иконки
        {


            if (newName != null)
            {
                gridInfo.Children.Remove(nameTextBlock);

                nameTextBlock.Text = newName;
                gridInfo.Children.Add(nameTextBlock);

                programAll[indexProg].Name = newName;

                var newTB = (TextBlock) gridButtons[indexProg].Children[2];
                newTB.Text = newName;
                
            }

            if (newIcon != null)
            {
                gridInfo.Children.Remove(iconBorderFon);

                ImageBrush ib = new ImageBrush(); 
                ib.ImageSource = new BitmapImage(
                    new Uri(newIcon) 
                    );
                ib.Stretch = Stretch.UniformToFill;
                iconBorderFon.Background = ib;

                gridInfo.Children.Add(iconBorderFon);

                programAll[indexProg].ImageIcon = newIcon;

                var newBF = (Border)gridButtons[indexProg].Children[1];
                newBF.Background = ib;

            }

            
        }

        private static void AddFonButton_Click(object sender, RoutedEventArgs e) //Изменение фона на окне информации
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "(*.JPEG;*.PNG)|*.jpg;*.png",
                Multiselect = false,
                ValidateNames = true
            };
            if (fileDialog.ShowDialog() == true)
            {
                var newIBF = (Border) gridInfo.Children[3];

                ImageBrush ib = new ImageBrush();
                ib.Stretch = Stretch.UniformToFill;
                ib.ImageSource = new BitmapImage(
                    new Uri(fileDialog.FileName)
                    );
                newIBF.Background = ib;

                programAll[indexProg].ImageFon = fileDialog.FileName;
            }
        }  


    }
}
