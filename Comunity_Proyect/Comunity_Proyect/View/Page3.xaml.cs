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
        PisosPropietarios pro;
        public Page3()
        {
            InitializeComponent();
            pisoManage.readPisos();
            propietarioManage.readPropietarios();
            pro = new PisosPropietarios(pisoManage.listPisos.Count(), propietarioManage.propietarioList.Count());
            pro.enlazarPisosYPorpietarios();
        }
    }
}
