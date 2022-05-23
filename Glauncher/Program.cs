using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media;

namespace Glauncher
{
  [Serializable]
  public partial class Program
  {

    public Program()
    {
    }

    public Program(int indexAll, int indent, string name, string fileName, string typeName, string imageIcon, string imageFon)
    {
      IndexAll = indexAll;
      Indent = indent;
      Name = name;
      FileName = fileName;
      TypeName = typeName;
      ImageIcon = imageIcon;
      ImageFon = imageFon;
    }


    public int Indent { get; set; }
    public int IndexAll { get; set; }
    public int IdProcess { get; set; }
    public int ExTime { get; set; }
    public string Name { get; set; }
    public string FileName { get; set; }
    public string TypeName { get; set; }
    public string ImageIcon { get; set; }
    public string ImageFon { get; set; }
    public bool AutoRunOn { get; set; }

    public static List<Program> programsList = new List<Program>();


    public static void DataValidation(string nameProg, string typeName, string iconName, string fileName)
    {
      bool error = false;

      if ((iconName == null) & (fileName != null))
      {
        iconName = System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().LastIndexOf("Glauncher") + 10) + "questionmark.jpg";
      }
      if ((typeName == null) & (fileName != null))
      {
        typeName = "program";
      }
      if (((nameProg == "") | (nameProg == null)) & (fileName != null))
      {
        nameProg = fileName.Substring(fileName.LastIndexOf(@"\") + 1, fileName.Length - fileName.LastIndexOf(@"\") - 5);
      }
      if (fileName == null)
      {
        ErorData erorData = new ErorData();
        erorData.ShowDialog();
        error = true;
      }
      if (error == false)
      {
        AllPage.NewProgramButton(nameProg, typeName, iconName, fileName);
      }

    }

    public static void AutoRun(Program program)
    {
      string autoRunGrid = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp";

      if (program.AutoRunOn == false)
      {
        File.Copy(program.FileName, autoRunGrid + '/' + Path.GetFileName(program.FileName));
        program.AutoRunOn = true;
        Settings.autorunBtn.Background = Brushes.DarkGreen;
      }
      else
      {
        File.Delete(autoRunGrid + '/' + Path.GetFileName(program.FileName));
        program.AutoRunOn = false;
        Settings.autorunBtn.Background = Brushes.Transparent;
      }
    }
  }
}
