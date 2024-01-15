using Comunity_Proyect.Domain;
using Comunity_Proyect.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
        Comunidad com;
        int num = 0;
        String[] portales;
        List<Piso> pisos = new List<Piso>();
        List<Propietario> propietarios = new List<Propietario>(); 
        public MainWindow()
        {
            InitializeComponent();
            page1 = new Page1();
            frameContenedor.Navigate(page1);
        }

        private void generateBttn_Click(object sender, RoutedEventArgs e)
        {
            page2 = new Page2();
            page2.messBox.Text = "Entrance " + (num+1);
            frameContenedor.Navigate(page2);
            generateBttn.Visibility = Visibility.Hidden;
            nextBttn.Visibility = Visibility.Visible;
            backBttn.Visibility = Visibility.Visible;
            com = new Comunidad();
            try
            {
                com.name = page1.nameBox.Text;
                com.address = page1.addressBox.Text;
                com.fundation = DateTime.ParseExact(page1.escogerFecha.Text.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                com.leasable = Int32.Parse(page1.areaBox.Text.ToString());
                if (page1.opcionListBox.SelectedIndex == 0)
                {
                    com.pool = true;
                }
                else
                {
                    com.pool = false;
                }

                com.entrances = Int32.Parse(page1.entrancesBox.Text.ToString());
                portales = new String[Int32.Parse(page1.entrancesBox.Text.ToString())];

            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error:" + ex.ToString());
            }
        }

        private void backBttn_Click(object sender, RoutedEventArgs e)
        {
            // TODO YET TO BE IMPLEMENTED
        }

        private void nextBttn_Click(object sender, RoutedEventArgs e)
        {
            if (num < com.entrances)
            {
                num++;
                page2.messBox.Text = "Entrance " + num;
                portales[num] = page2.stairsBox.Text.ToString() + page2.highsBox.Text.ToString() + page2.initialLetterBox.Text.ToString() + page2.finalLetterBox.Text.ToString();
                
                
                
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
