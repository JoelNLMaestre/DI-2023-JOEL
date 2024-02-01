using CrystalView.Domain;
using SAPBusinessObjects.WPF.Viewer;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CrystalView.View
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Informe : Window
    {
        public Informe()
        {
            InitializeComponent();
        }

        private void CrystalReportsViewer_Loaded(object sender, RoutedEventArgs e)
        {
            People p = new People();
            DataTable dataTable = p.getP();
            CrystalReport1 cr1 = new CrystalReport1();
            cr1.Database.Tables["People"].SetDataSource(dataTable);
            crystal.ViewerCore.ReportSource = cr1;
        }
    }
}
