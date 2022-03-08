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

namespace Glauncher
{  
    public partial class AllPage : Page
    {

        public AllPage()
        {
            InitializeComponent();
            scrollfieldAll = scrollFieldAll;
            
        }

        private static int indent = 0; //Поле отступа следующей кнопки

        private static Grid scrollfieldAll; //Рабочее поле Grid куда добавляются кнопки


        public static void NewProgramButton()
        {

            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(
                new Uri(@"C:\Users\super\Pictures\Saved Pictures\wot.jpg")
                );
            Border imageBorder = new Border()
            {
                Height = 50,
                Width = 50,
                Margin = new Thickness(30, indent + 10, 0, 0),
                Background = ib,
                CornerRadius = new CornerRadius(25),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.White
            };

            TextBlock textBlockName = new TextBlock()
            { 
                Foreground = Brushes.White,
                FontSize = 20,
                FontFamily = new FontFamily("Calibri"),
                Margin = new Thickness(95, indent + 22, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
            };
            textBlockName.Text = "World of Tanks";

            Style style = Application.Current.FindResource("menuButtonStyle") as Style;
            Button programbtn = new Button();
            programbtn.Style = style;  
            programbtn.Margin = new Thickness(20, indent, 0, 0);

            scrollfieldAll.Children.Add(programbtn);
            scrollfieldAll.Children.Add(imageBorder);
            scrollfieldAll.Children.Add(textBlockName);

            indent += 80;
        }

        

    }
}
