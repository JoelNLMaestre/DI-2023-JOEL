using Ejercicio2.Domain;
using Ejercicio2.Persistance.Manages;
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
using Ejercicio2.Domain;

namespace Ejercicio2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            Domain.Matrix matriz;
            Figures figura = new Figures();
            Random r = new Random();
            matriz = new Domain.Matrix(Int32.Parse(txtA.Text), Int32.Parse(txtB.Text));
            int posX = r.Next(0, Int32.Parse(txtA.Text));
            int posY = r.Next(0, Int32.Parse(txtB.Text));
            matriz.tabla[posX, posY] = 'B';
            figura.Bishop(matriz.tabla);
            String enviar = "";
            for (int i = 0;i < matriz.tabla.GetLength(0);i++)
            {
                for (int j = 0; j < matriz.tabla.GetLength(1); j++)
                {
                    enviar += " "+matriz.tabla[i,j];
                }
                enviar += "\n";
            }
            texto.Text = enviar;
        }
    }
}
