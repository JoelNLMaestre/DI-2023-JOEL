using ExampleMVCnoDatabase.Domain;
using Newtonsoft.Json;
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

namespace ExampleMVCnoDatabase
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            People people = new People();
            try
            {
                people.readP();
            }catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar el JSON: {ex.Message}");
            }

            dgvPeople.ItemsSource = people.getListPeople();
            btnDel.IsEnabled = false;
            btnNew.IsEnabled = false;
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
            }
        }

        private void btnExample_Click(object sender, RoutedEventArgs e)
        {
            if (dgvPeople.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Do you want to modify this person?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    People p = (People)dgvPeople.SelectedItem;
                    p.readP();
                    p.name = txtName.Text;
                    p.age = Convert.ToInt32(txtAge.Text);
                    p.update();
                    dgvPeople.Items.Refresh();
                }
            }
            else
            {
                if (MessageBox.Show("Do you want to add this person?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    People p = new People(txtName.Text, Int32.Parse(txtAge.Text));
                    p.readP();
                    p.insert();
                    p.last();
                    ((List<People>)dgvPeople.ItemsSource).Add(p);
                    dgvPeople.Items.Refresh();
                }
            }
        }

        private void start()
        {
            txtName.Text = "";
            txtAge.Text = "";

            btnDel.IsEnabled = false;
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
                people.readP();
                people.delete();
                List<People> lst = (List<People>)dgvPeople.ItemsSource;
                lst.Remove(people);
                dgvPeople.Items.Refresh();
                dgvPeople.ItemsSource = lst;
                start();
            }
        }
    }
}

    
