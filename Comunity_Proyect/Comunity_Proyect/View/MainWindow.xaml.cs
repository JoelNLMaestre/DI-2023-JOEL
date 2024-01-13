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
        public MainWindow()
        {
            InitializeComponent();
            page1 = new Page1();
            frameContenedor.Navigate(page1);
        }

        private void generateBttn_Click(object sender, RoutedEventArgs e)
        {
            page2 = new Page2();
            page2.messBox.Text = "hola mundo";
            frameContenedor.Navigate(page2);
            generateBttn.Visibility = Visibility.Hidden;
            nextBttn.Visibility = Visibility.Visible;
            backBttn.Visibility = Visibility.Visible;

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
            page2.messBox.Text = "  ";
        }
    }
}
