using Comunity_Proyect.View;
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

namespace Comunity_Proyect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Page1 page1;
        Page2 page2;
        int entrances;
        int num = 1;
        public MainWindow()
        {
            InitializeComponent();
            page1 = new Page1();
            frameContenedor.Navigate(page1);
        }

        private void generateBttn_Click(object sender, RoutedEventArgs e)
        {
            page2 = new Page2();
            page2.messBox.Text = "Entrance" + num;
            frameContenedor.Navigate(page2);
            generateBttn.Visibility = Visibility.Hidden;
            nextBttn.Visibility = Visibility.Visible;
            backBttn.Visibility = Visibility.Visible;
            entrances = Int32.Parse(page1.entrancesBox.Text);
        }

        private void backBttn_Click(object sender, RoutedEventArgs e)
        {
            frameContenedor.Navigate(page1);
            generateBttn.Visibility = Visibility.Visible;
            nextBttn.Visibility = Visibility.Hidden;
            backBttn.Visibility = Visibility.Hidden;
        }

        private void nextBttn_Click(object sender, RoutedEventArgs e)
        {
            if (num != entrances)
            {
                num++;
                page2.messBox.Text = "Entrance " + num;
                page2.stairsBox.Text = " ";
                page2.highsBox.Text = " ";
                page2.initialLetterBox.Text = " ";
                page2.finalLetterBox.Text = " ";
            }
            else
            {
                frameContenedor.Navigate(page1);
            }
        }
    }
}
