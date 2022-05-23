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
 
  public partial class ErorData : Window
  {
    public ErorData()
    {
      InitializeComponent();
      erorData = this;
    }

    public static ErorData erorData;

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
      AddApp.app.Close();
      erorData.Close();
      
    }
  }
}
