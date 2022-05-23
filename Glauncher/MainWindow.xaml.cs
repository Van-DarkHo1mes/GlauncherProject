﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Glauncher
{
  public partial class MainWindow : Window
  {

    public static MainWindow window;

    public MainWindow()
    {
      InitializeComponent();

      DeserializeXML();
      RecoveryButton();

      window = this;

    }

    AllPage allPage = new AllPage();


    public static void SerializeXML(List<Program> programList, User user)
    {
      
      XmlSerializer xml1 = new XmlSerializer(typeof(List<Program>));
      using (FileStream fs = new FileStream("Program.xml", FileMode.OpenOrCreate))
      {
        xml1.Serialize(fs, programList);
      }

      XmlSerializer xml2 = new XmlSerializer(typeof(User));
      using (FileStream fs = new FileStream("User.xml", FileMode.OpenOrCreate))
      {
        xml2.Serialize(fs, user);
      }
    }

    private void DeserializeXML()
    {

      try
      {
        XmlSerializer xml1 = new XmlSerializer(typeof(List<Program>));
        using (FileStream fs = new FileStream("Program.xml", FileMode.OpenOrCreate))
        {
          Program.programsList = (List<Program>)xml1.Deserialize(fs);
        }
      }
      catch (Exception){}

      try
      {
        XmlSerializer xml2 = new XmlSerializer(typeof(User));
        using (FileStream fs = new FileStream("User.xml", FileMode.OpenOrCreate))
        {

          UserWindow.user = (User)xml2.Deserialize(fs);
        }
      }
      catch (Exception) { }
    }

    private void RecoveryButton()
    {
      for (int i = 0; i < Program.programsList.Count; i++)
      {
        var program = Program.programsList[i];
        AllPage.RecoveryProgramButton(program.Name, program.FileName, program.ImageIcon, program.FileName);
      }
    }



    private void MovingWindow(object sender, RoutedEventArgs e)   //Метод для перемещения окна на экране
    {
      if (Mouse.LeftButton == MouseButtonState.Pressed)
      {
        MainWindow.window.DragMove();
      }
    }

    private void Button_Click_Exit(object sender, RoutedEventArgs e) //Метод завершения работы программы
    {
      SerializeXML(Program.programsList, UserWindow.user);

      Application.Current.Shutdown();
    }

    public void AddButton_Click(object sender, RoutedEventArgs e) //Открывает окно с добавлением программ
    {
      AddApp addApp = new AddApp();
      addApp.ShowDialog();
    }

    private void AllButton_Click(object sender, RoutedEventArgs e) //Открывает страницу "ВСЕ", через Frame
    {
      WorkField.Content = allPage;
    }

    private void UserButton_Click(object sender, RoutedEventArgs e)
    {
      UserWindow userWindow = new UserWindow();
      userWindow.ShowDialog();
    }
  }
}
