using Ejercicio3.Domain;
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

namespace Ejercicio3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            People people = new People();
            people.readP();
            dgvPeople.ItemsSource = people.getListPeople();
            btnDel.IsEnabled = false;
            btnNew.IsEnabled = false;
            txtName.Text = "";
            txtAge.Text = "";
            txtNif.Text = "";
            txtSurname.Text = "";
        }


        private void dgvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvPeople.SelectedItems.Count > 0)
            {
                btnNew.IsEnabled = true;
                btnDel.IsEnabled = true;
                People people = (People)dgvPeople.SelectedItems[0];
                txtName.Text = people.name;
                txtAge.Text = people.age.ToString();
                txtSurname.Text = people.surname;
                txtNif.Text = people.nif;
            }
        }



        private void start()
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtNif.Text = "";
            txtSurname.Text = "";

            btnDel.IsEnabled = false;
            btnNew.IsEnabled = false;
            dgvPeople.SelectedItems.Clear();
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            start();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this person?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                People people = (People)dgvPeople.SelectedItem;
                people.delete();
                List<People> lst = (List<People>)dgvPeople.ItemsSource;
                lst.Remove(people);
                dgvPeople.Items.Refresh();
                dgvPeople.ItemsSource = lst;
                start();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!btnNew.IsEnabled)
            {
                if (MessageBox.Show("Do you want to add this person", "Confirmacion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    People p = new People(txtName.Text, Int32.Parse(txtAge.Text));
                    p.insert();
                    p.last();
                    ((List<People>)dgvPeople.ItemsSource).Add(p);
                    dgvPeople.Items.Refresh();
                    start();
                }
            }
            else
            {
                if (MessageBox.Show("Do you want to modify this person", "Confirmacion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    People people = (People)dgvPeople.SelectedItems[0];
                    people.name = txtName.Text;
                    people.surname = txtSurname.Text;
                    people.nif = txtNif.Text;
                    try
                    {
                        people.age = Int32.Parse(txtAge.Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("this text must be a number");
                    }
                    dgvPeople.Items.Refresh();
                    start();
                }
            }
        }
    }
}
