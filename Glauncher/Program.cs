using System;
using System.Collections.Generic;
using System.Text;

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
      if ((nameProg == "") & (nameProg == null) & (fileName != null))
      {
        nameProg = fileName.Substring(fileName.LastIndexOf(@"\") + 1, fileName.LastIndexOf("."));
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
  }

  [Serializable]
  public partial class Game : Program
  {
    public Game()
    {
    }

    public int IndexGame { get; set; }

    public static List<Game> gamesList = new List<Game>();

    public Game(int indexAll, int indent, string name, string fileName, string typeName, string imageIcon, string imageFon)
    {
      IndexAll = indexAll;
      Indent = indent;
      Name = name;
      FileName = fileName;
      TypeName = typeName;
      ImageIcon = imageIcon;
      ImageFon = imageFon;
    }
  }

  [Serializable]
  public partial class AppProgram : Program
  {
    public AppProgram()
    {
    }

    public int IndexApp { get; set; }

    public static List<AppProgram> appsList = new List<AppProgram>();

    public AppProgram(int index, int indent, string name, string fileName, string typeName, string imageIcon, string imageFon)
    {
      IndexAll = index;
      Indent = indent;
      Name = name;
      FileName = fileName;
      TypeName = typeName;
      ImageIcon = imageIcon;
      ImageFon = imageFon;
    }
  }
}
