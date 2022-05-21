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
    public string Name { get; set; }
    public string FileName { get; set; }
    public string TypeName { get; set; }
    public string ImageIcon { get; set; }
    public string ImageFon { get; set; }

    public static List<Program> programsList = new List<Program>();
  }

  [Serializable]
  public partial class Game : Program
  {
    public Game()
    {
    }

    public int IndexGame { get; set; }

    public static List<Game> gamesList = new List<Game>();

    public Game(int indexAll, int indexGame, int indent, string name, string fileName, string typeName, string imageIcon, string imageFon)
    {
      IndexAll = indexAll;
      IndexGame = indexGame;
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

    public AppProgram(int index, int indexApp, int indent, string name, string fileName, string typeName, string imageIcon, string imageFon)
    {
      IndexAll = index;
      IndexApp = indexApp;
      Indent = indent;
      Name = name;
      FileName = fileName;
      TypeName = typeName;
      ImageIcon = imageIcon;
      ImageFon = imageFon;
    }
  }
}
