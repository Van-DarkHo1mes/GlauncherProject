using System;
using System.Collections.Generic;
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

namespace Glauncher
{
    public partial class Program
    {

    }

    public partial class Game : Program
    {

    }

    public partial class MainWindow : Window
    {

        public static MainWindow window;

        private void MovingWindow(object sender, RoutedEventArgs e)   //Метод для перемещения окна на экране
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.window.DragMove();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            window = this;
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e) //Метод завершения работы программы
        {
            Application.Current.Shutdown();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e) //ОТкрывает окно с добавлением программ
        {
            AddApp addApp = new AddApp();
            addApp.ShowDialog();
        }

    }
}
