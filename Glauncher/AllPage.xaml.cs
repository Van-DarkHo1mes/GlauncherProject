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
using System.Xml.Serialization;
using System.IO;
using System.Threading;

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

      playButton.Click += (o, e) => playButton_Click(o, e, indexProg);
      DeleteButton.Click += (o, e) => DeleteButton_Click(o, e, indexProg);
    }


    private static List<Button> progButtons = new List<Button>(); //Лист всех кнопок
    private static List<Panel> gridButtons = new List<Panel>(); //Лист всех контейнеров кнопок
    private static List<String> processStartName = new List<String>();
    private static List<Process> processStart = new List<Process>();
    private static List<Stopwatch> stopwatches = new List<Stopwatch>();

    private static FrameworkElement buttonProg;


    private static int indexProg = 0; //Индек активной программы
    private static int indent = 0; //Поле отступа следующей кнопки
    public static int IndexAll = Program.programsList.Count; //Поле проядка кнопок программ
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

    private static Style styleDeleteButton = Application.Current.FindResource("DeleteButton") as Style;
    private static Button DeleteButton = new Button()
    {
      Style = styleDeleteButton,
      Margin = new Thickness(20, 0, 0, 20),
      VerticalAlignment = VerticalAlignment.Bottom,
      HorizontalAlignment = HorizontalAlignment.Left,

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


    public static void RecoveryProgramButton(string nameProg, string typeName, string iconName, string fileName) //Собирает Программную кнопку на странице ВСЕ
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

      indent += 80; //Переменная отступа
    }


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


      Program program = new Program(IndexAll, indent, nameProg, fileName, typeName, iconName, defoltFon);
      Program.programsList.Add(program);

      if (typeName == "game")
      {
        Game game = new Game(IndexAll, indent, nameProg, fileName, iconName, iconName, defoltFon);

        Game.gamesList.Add(game);
      }

      if (typeName == "appProgram")
      {
        AppProgram appProgram = new AppProgram(IndexAll, indent, nameProg, fileName, iconName, iconName, defoltFon);

        AppProgram.appsList.Add(appProgram);
      }

      indent += 80; //Переменная отступа
    }



    public static void Programbtn_Click(object sender, RoutedEventArgs e) //Метод создания окна информации
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
      nameTextBlock.Text = Program.programsList[indexProg].Name;

      
      

      foreach (var process in processStartName)
      {
        if (process == Program.programsList[indexProg].FileName)
        {
          playButton.Content = "ЗАКРЫТЬ";
          break;
        }
        else
        {
          playButton.Content = "ЗАПУСК";
        }
      }


      ImageBrush ib = new ImageBrush(); //Изображение на окне информации
      ib.ImageSource = new BitmapImage(
          new Uri(Program.programsList[indexProg].ImageIcon)
          );
      ib.Stretch = Stretch.UniformToFill;
      iconBorderFon.Background = ib;

      settingsButton.Click += (o, e) => SettingsButton_Click(o, e, indexProg);
      

      ImageBrush ibf = new ImageBrush();
      ibf.Stretch = Stretch.Fill;
      ibf.ImageSource = new BitmapImage(
          new Uri(Program.programsList[indexProg].ImageFon)
          );

      borderImageFon.Background = ibf;

      addFonButton.Click += AddFonButton_Click;

      gridInfo.Children.Add(DeleteButton);
      gridInfo.Children.Add(nameTextBlock);
      gridInfo.Children.Add(playButton);
      gridInfo.Children.Add(borderImageFon);
      gridInfo.Children.Add(addFonButton);
      gridInfo.Children.Add(iconBorderFon);
      gridInfo.Children.Add(settingsButton);

    }

    private static void SettingsButton_Click(object o, RoutedEventArgs e, int indexProg) //Открывает окно настроек
    {
      Settings settings = new Settings();
      settings.ShowDialog();

    }



    private static void playButton_Click(object sender, RoutedEventArgs e, int indexProg) //Запускает и закрывает программу
    {

      bool stex = true; 
      int deli = -1;
      int t = 0;

      foreach (var process in processStartName)
      {
        if (process == Program.programsList[indexProg].FileName)
        {
          int i = 0;
          foreach (var proc in processStart)
          {
            i++;
            if (proc.Id == Program.programsList[indexProg].IdProcess)
            {
              stex = false;
              proc.Kill();
              stopwatches[t].Stop();
              TimeSpan ts = stopwatches[t].Elapsed;
              
              Program.programsList[indexProg].ExTime = ts.Hours * 3600 + ts.Minutes * 60 + ts.Seconds;
              deli = i - 1;
              playButton.Content = "ЗАПУСК";
            }
          }
        }
        t++;
      }

      if (stex == true)
      {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        stopwatches.Add(stopwatch);

        var proc = Process.Start(Program.programsList[indexProg].FileName);
        processStartName.Add(Program.programsList[indexProg].FileName);
        processStart.Add(proc);
        try
        {
          Program.programsList[indexProg].IdProcess = proc.Id;
        }
        catch (Exception)
        {
        }
        playButton.Content = "ЗАКРЫТЬ";
      }

      if (deli != -1)
      {
        processStart.RemoveAt(deli);
        processStartName.RemoveAt(deli);
      }

    }


    public static void OpenFile() //Просмотр файлов в окне настроек
    {
      Process.Start("explorer.exe", Program.programsList[indexProg].FileName.Substring(0, Program.programsList[indexProg].FileName.LastIndexOf(@"\") + 1));
    }


    public static void RenameInfoProg(string newName, string newIcon) //Измение имени и/или иконки
    {


      if ((newName != null) & (newName != ""))
      {
        gridInfo.Children.Remove(nameTextBlock);

        nameTextBlock.Text = newName;
        gridInfo.Children.Add(nameTextBlock);

        Program.programsList[indexProg].Name = newName;

        var newTB = (TextBlock)gridButtons[indexProg].Children[2];
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

        Program.programsList[indexProg].ImageIcon = newIcon;

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
        Border newIBF = (Border)gridInfo.Children[3];

        ImageBrush ib = new ImageBrush();
        ib.Stretch = Stretch.UniformToFill;
        ib.ImageSource = new BitmapImage(
            new Uri(fileDialog.FileName)
            );
        newIBF.Background = ib;

        Program.programsList[indexProg].ImageFon = fileDialog.FileName;
      }
    }

    private static void DeleteButton_Click(object sender, RoutedEventArgs e, int indexProg)
    {
      try
      {
        for (int i = Program.programsList.Count - 1; i > 0; i--)
        {
          Program.programsList[i].Indent = Program.programsList[i - 1].Indent;
          Program.programsList[i].IndexAll = Program.programsList[i - 1].IndexAll;
        }
      }
      catch (Exception)
      {
      }
      

      Program.programsList.RemoveAt(indexProg);
      gridButtons.Clear();
      progButtons.Clear();
      IndexAll--;

      scrollfieldAll.Children.Clear();
      gridInfo.Children.Clear();
      openIndexInfo = false;
      indent = 0;

      for (int i = 0; i < Program.programsList.Count; i++)
      {
        var program = Program.programsList[i];
        RecoveryProgramButton(program.Name, program.FileName, program.ImageIcon, program.FileName);
      }
    } 

  }
}
