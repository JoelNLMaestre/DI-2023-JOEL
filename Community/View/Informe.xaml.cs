using Community.Domain;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Community.View
{
    /// <summary>
    /// Lógica de interacción para Page4.xaml
    /// </summary>
    public partial class Informe : Page
    {
        public Informe()
        {
            InitializeComponent();
        }

        private void CrystalReportsViewer_Loaded(object sender, RoutedEventArgs e)
        {
            Propietario p = new Propietario();
            DataTable dt = p.getPro();
            CrystalReport1 crystalReport1 = new CrystalReport1();
            crystalReport1.Database.Tables["Propietarios"].SetDataSource(dt);
            CRInforme.ViewerCore.ReportSource = crystalReport1;
        }
    }
}
