using Comunity_Proyect.Persistence.Manage;
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

namespace Comunity_Proyect.View
{
    /// <summary>
    /// Lógica de interacción para Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        PisoManage pisoManage = new PisoManage();
        PropietarioManage propietarioManage = new PropietarioManage();
        ComunidadManage ComunidadManage = new ComunidadManage();
        PisosPropietarios pro;
        public Page3()
        {
            InitializeComponent();
            pisoManage.readPisos();
            propietarioManage.readPropietarios();
            ComunidadManage.readComunidad();
            pro = new PisosPropietarios(pisoManage.listPisos.Count(), propietarioManage.propietarioList.Count());
            pro.enlazarPisosYPorpietarios();

        }

        private void gatekeeper_Checked(object sender, RoutedEventArgs e)
        {
            ComunidadManage.lista[0].gateKeeper = "yes";
        }

        private void showers_Checked(object sender, RoutedEventArgs e)
        {
            ComunidadManage.lista[0].showers = "yes";
        }

        private void exercisearea_Checked(object sender, RoutedEventArgs e)
        {
            ComunidadManage.lista[0].exercise = "yes";
        }

        private void meetingroom_Checked(object sender, RoutedEventArgs e)
        {
            ComunidadManage.lista[0].meeting = "yes";
        }

        private void tennis_Checked(object sender, RoutedEventArgs e)
        {
            ComunidadManage.lista[0].tennis = "yes";
        }

        private void padel_Checked(object sender, RoutedEventArgs e)
        {
            ComunidadManage.lista[0].padel = "yes";
        }

        private void finalizarCominidad_Click(object sender, RoutedEventArgs e)
        {
            ComunidadManage.ModuficarComunidad(ComunidadManage.lista[0]);

        }
    }
}
