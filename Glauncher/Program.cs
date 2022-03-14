using System;
using System.Collections.Generic;
using System.Text;

namespace Glauncher
{
    public partial class Program
    {
        public int Indent { get; set; }
        public int IndexAll { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string TypeName { get; set; }
        public string ImageIcon { get; set; }
    }

    public partial class Game : Program
    {
        public int IndexGame { get; set; }

        public Game(int indexAll,int indexGame, int indent, string name, string fileName, string typeName, string imageIcon)
        {
            IndexAll = indexAll;
            IndexGame = indexGame;
            Indent = indent;
            Name = name;
            FileName = fileName;
            TypeName = typeName;
            ImageIcon = imageIcon;
        }
    }

    public partial class AppProgram : Program
    {
        public int IndexApp { get; set; }

        public AppProgram(int index, int indexApp, int indent, string name, string fileName, string typeName, string imageIcon)
        {
            IndexAll = index;
            IndexApp = indexApp;
            Indent = indent;
            Name = name;
            FileName = fileName;
            TypeName = typeName;
            ImageIcon = imageIcon;
        }
    }
}
