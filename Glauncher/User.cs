using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Glauncher
{
  [Serializable]
  public class User
  {
    public string Name;
    public string Icon;
    public bool AutoRunOn;

    public static void AutoRunGl()
    {
      string autoRunGrid = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp";
      string programName = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("netcoreapp3.1") + 13) + "\\Glauncher.exe";

      if (UserWindow.user.AutoRunOn == false)
      {
        File.Copy(programName, autoRunGrid + '/' + Path.GetFileName(programName));
        UserWindow.user.AutoRunOn = true;
        UserWindow.glRun.Background = Brushes.DarkGreen;
      }
      else
      {
        File.Delete(autoRunGrid + '/' + Path.GetFileName(programName));
        UserWindow.user.AutoRunOn = false;
        UserWindow.glRun.Background = Brushes.Transparent;
      }
    }

    public static void DeleteData(object sender, RoutedEventArgs e)
    {

      for (int indexProg = 0; indexProg <= Program.programsList.Count;)
      {
        if (Program.programsList.Count == 0) { break; }
        AllPage.DeleteButton_Click(sender, e, indexProg);
      }

      try
      {
        File.Delete(Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("netcoreapp3.1") + 13) + "\\Program.xml");
      }
      catch {} 
    }
    
  }
}
