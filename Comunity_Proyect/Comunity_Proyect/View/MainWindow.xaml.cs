using Comunity_Proyect.Domain;
using Comunity_Proyect.Persistence.Manage;
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
        Page3 page3;
        Comunidad com;
        int num = 0;
        int port = 0;
        Portal[] portales;
        PisoManage pisoManageGeneral = new PisoManage();
        PropietarioManage propManageGeneral = new PropietarioManage(); 
        public MainWindow()
        {
            InitializeComponent();
            page1 = new Page1();
            frameContenedor.Navigate(page1);
        }

        private void generateBttn_Click(object sender, RoutedEventArgs e)
        {
            portales = new Portal[Int32.Parse(page1.entrancesBox.Text.ToString())];
            page2 = new Page2();
            page2.messBox.Text = "Entrance " + (num+1);
            frameContenedor.Navigate(page2);
            com = new Comunidad();
            try
            {
                com.name = page1.nameBox.Text.ToString();
                com.address = page1.addressBox.Text.ToString();
                com.fundation = page1.escogerFecha.Text.ToString();
                com.leasable = Int32.Parse(page1.areaBox.Text.ToString());
                if (page1.opcionListBox.SelectedIndex == 0)
                {
                    com.pool = true;
                }
                else
                {
                    com.pool = false;
                }

                com.entrances = Int32.Parse(page1.entrancesBox.Text);
                com.cm.insertComunidad(com);
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            if(com.entrances == 1)
            {
                generateBttn.Visibility = Visibility.Hidden;
                finishBttn.Visibility = Visibility.Visible;
                backBttn.Visibility = Visibility.Visible;
            }
            else
            {
                generateBttn.Visibility = Visibility.Hidden;
                nextBttn.Visibility = Visibility.Visible;
                backBttn.Visibility = Visibility.Visible;
            }
           
        }

        private void backBttn_Click(object sender, RoutedEventArgs e)
        {
            nextBttn.Visibility=Visibility.Hidden;
            backBttn.Visibility= Visibility.Hidden;
            finishBttn.Visibility = Visibility.Hidden;
            generateBttn.Visibility = Visibility.Visible;
            pisoManageGeneral.listPisos.Clear();
            propManageGeneral.propietarioList.Clear();
            frameContenedor.Navigate(page1);
            page2.stairsBox.Text = " ";
            page2.highsBox.Text = " ";
            page2.initialLetterBox.Text = " ";
            page2.finalLetterBox.Text = " ";
            num = 0;
        }

        private void nextBttn_Click(object sender, RoutedEventArgs e)
        {
            num++;
            if (num == (com.entrances-1))
            {
                nextBttn.Visibility = Visibility.Hidden;
                finishBttn.Visibility = Visibility.Visible;
            }
            if (num < com.entrances)
            {
                portales[port] = new Portal(num, Int32.Parse(page2.stairsBox.Text), Int32.Parse(page2.highsBox.Text), page2.initialLetterBox.Text[0], page2.finalLetterBox.Text[0]);

                pisoManageGeneral.generarPisosPorPortal(portales[port]);
                propManageGeneral.generarPropietariosPorPortal(portales[port]);
                port++;
            }
            
            page2.messBox.Text = "Entrance " + (num+1);

            page2.stairsBox.Clear();
            page2.highsBox.Clear();
            page2.initialLetterBox.Clear();
            page2.finalLetterBox.Clear();
        }

        private void finishBttn_Click(object sender, RoutedEventArgs e)
        {
            num++;
            portales[port] = new Portal(num, Int32.Parse(page2.stairsBox.Text), Int32.Parse(page2.highsBox.Text), page2.initialLetterBox.Text[0], page2.finalLetterBox.Text[0]);

            pisoManageGeneral.generarPisosPorPortal(portales[port]);
            propManageGeneral.generarPropietariosPorPortal(portales[port]);
            pisoManageGeneral.reparteAlmacen();
            pisoManageGeneral.reparteParking();

            pisoManageGeneral.insertPisos();
            propManageGeneral.insertPropietarios();

            page2.stairsBox.Clear();
            page2.highsBox.Clear();
            page2.initialLetterBox.Clear();
            page2.finalLetterBox.Clear();
            page3 = new Page3();
            frameContenedor.Navigate(page3);
        }
    }
}
