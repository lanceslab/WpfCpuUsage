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
using System.Windows.Shapes;

namespace WpfCpuUsage
{
    /// <summary>
    /// Interaction logic for MyOptions.xaml
    /// </summary>
    public partial class MyOptions : Window
    {
        public MyOptions()
        {
            InitializeComponent();
        }

        private void mySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //int mySliderValue = Convert.ToInt32(e);

            //MainWindow mainWindow = new MainWindow();
           
            //switch (mySliderValue)
            //{
            //    case 1:
            //    case 10:
            //        mainWindow.Background.Opacity = 0.1;
            //        break;
            //    case 20:
            //    case 29:
            //        mainWindow.Background.Opacity = 0.2;
            //        break;

            //    case 30:
            //    case 39:
            //        mainWindow.Background.Opacity = 0.3;
            //        break;

            //    case 40:
            //    case 49:
            //        mainWindow.Background.Opacity = 0.4;
            //        break;

            //    case 50:
            //    case 59:
            //        mainWindow.Background.Opacity = 0.5;
            //        break;

            //    case 60:
            //    case 69:
            //        mainWindow.Background.Opacity = 0.6;
            //        break;

            //    case 70:
            //    case 79:
            //        mainWindow.Background.Opacity = 0.7;
            //        break;

            //    case 80:
            //    case 89:
            //        mainWindow.Background.Opacity = 0.8;
            //        break;

            //    case 90:
            //    case 99:
            //        mainWindow.Background.Opacity = 0.9;
            //        break;

            //    case 100:
            //        mainWindow.Background.Opacity = 1.0;
            //        break;
            //}



        }





    }
}
