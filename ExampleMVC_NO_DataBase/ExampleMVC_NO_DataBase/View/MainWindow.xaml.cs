using ExampleMVC_NO_DataBase.Domain;
using ExampleMVC_NO_DataBase.Persistence.Manages;
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

namespace ExampleMVC_NO_DataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            People pm = new People();
            pm.readP();
            dgPeople.ItemsSource = pm.GetList();
        }
        private void dgPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("selection changed");
        }
        private void btnExample_Click(object sender, RoutedEventArgs e)
        {

            String name = boxExample.Text;
            People people = new People(name);
            people.addList(people);
            people.readP();
            dgPeople.ItemsSource = people.GetList();
        }
    }
}
