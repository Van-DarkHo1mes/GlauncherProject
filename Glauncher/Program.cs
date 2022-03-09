using System;
using System.Collections.Generic;
using System.Text;

namespace Glauncher
{
    public partial class Program
    {
        public int Indent { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string TypeName { get; set; }
        public string ImageIcon { get; set; }
    }

    public partial class Game : Program
    {
        public Game(int index, int indent, string name, string fileName, string typeName, string imageIcon)
        {
            Index = index;
            Indent = indent;
            Name = name;
            FileName = fileName;
            TypeName = typeName;
            ImageIcon = imageIcon;
        }
    }
}
