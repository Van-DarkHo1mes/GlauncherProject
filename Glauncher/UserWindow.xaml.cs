using Microsoft.Win32;
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
  
  public partial class UserWindow : Window
  {
    public UserWindow()
    {
      InitializeComponent();

      window = this;
      nameBox = NameBox;
      iconImage = IconImage;
      glRun = GlRun;

      StartWindow();
    }

    public static User user = new User();
    private static UserWindow window;

    private static TextBox nameBox;
    private static Border iconImage;
    public static Button glRun;

    private void DeleteSaveButton_Click(object sender, RoutedEventArgs e)
    {
      User.DeleteData(sender, e);
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      if ((NameBox.Text != "") & (NameBox.Text != null)) { user.Name = NameBox.Text; }

      MainWindow.SerializeXML(Program.programsList, user);
    }

    private void GlRunButton_Click(object sender, RoutedEventArgs e)
    {
      User.AutoRunGl();
    }

    private void NewIconButton_Click(object sender, RoutedEventArgs e)
    {

      OpenFileDialog fileDialog = new OpenFileDialog()
      {
        Filter = "(*.JPEG;*.PNG)|*.jpg;*.png",
        Multiselect = false,
        ValidateNames = true
      };
      if (fileDialog.ShowDialog() == true)
      {
        user.Icon = fileDialog.FileName; 

        ImageBrush ib = new ImageBrush();
        ib.ImageSource = new BitmapImage(
            new Uri(user.Icon)
            );
        IconImage.Background = ib; 
      }

    }

    private void ButtonClick_Exit(object sender, RoutedEventArgs e)
    {
      window.Close();
    }

    private static void StartWindow()
    {
      nameBox.Text = user.Name;

      try
      {
        ImageBrush ib = new ImageBrush();
        ib.ImageSource = new BitmapImage(
            new Uri(user.Icon)
            );
        iconImage.Background = ib;
      }
      catch { }
    }
  }
}
