using Dhont_Proyect.Domain;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Dhont_Proyect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Party party = new Party();
            dgvParty.ItemsSource = party.pm.listParty;
            dgvSeats.ItemsSource = party.pm.listParty;
            btnDel.IsEnabled = false;
            btnNew.IsEnabled = false;
            start();
        }

        private void start()
        {
            txtName.Text = "";
            txtPresident.Text = "";
            txtAcronym.Text = "";

            btnDel.IsEnabled = false;
            btnNew.IsEnabled = false;
            dgvParty.SelectedItems.Clear();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!btnNew.IsEnabled)
            {
                if (MessageBox.Show("Do you want to add this Party", "Confirmacion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Party party = new Party(txtAcronym.Text,txtName.Text,txtPresident.Text);
                    dgvParty.ItemsSource = party.pm.listParty;
                    party.readP();
                    ((List<Party>)dgvParty.ItemsSource).Add(party);
                    dgvParty.Items.Refresh();
                    start();
                }
            }
            else
            {
                if (MessageBox.Show("Do you want to modify this Party", "Confirmacion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Party party = (Party)dgvParty.SelectedItems[0];
                    party.name = txtName.Text;
                    party.acronym = txtAcronym.Text;
                    party.president = txtPresident.Text;
                    dgvParty.Items.Refresh();
                    start();
                }
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this Party?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Party people = (Party)dgvParty.SelectedItem;

                List<Party> lst = (List<Party>)dgvParty.ItemsSource;
                lst.Remove(people);
                dgvParty.Items.Refresh();
                dgvParty.ItemsSource = lst;
                start();
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            start();
        }

        private void dgvParty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvParty.SelectedItems.Count > 0)
            {
                btnNew.IsEnabled = true;
                btnDel.IsEnabled = true;
                Party party = (Party)dgvParty.SelectedItems[0];
                txtName.Text = party.name;
                txtAcronym.Text = party.acronym;
                txtPresident.Text = party.president;
            }
        }

        private void btnSimular_Click(object sender, RoutedEventArgs e)
        {
            Party p = new Party();
            p.pm.readParty();
            dgvSeats.ItemsSource = dgvParty.ItemsSource;
            int[] seats = repatirVotos((Int32.Parse(textTotalVotes.Text)-Int32.Parse(textAbstension.Text)-Int32.Parse(textNullVotes.Text)), Int32.Parse(editVotos.Text));
            double[] votosperc = { 35.25, 24.75, 15.75, 14.25, 3.75, 3.25, 1.5, 0.5, 0.25, 0.25, 0.50 };
            double[] votosXpartido = new double[votosperc.Length];
            for (int i = 0; i < votosperc.Length; i++)
            {
                votosXpartido[i] = (votosperc[i] / 100) * 4127969;
            }
            List<Party> lst = (List<Party>)dgvSeats.ItemsSource;
            int count = 0;
            foreach( Party p1 in  lst )
            {
                p1.votes = (int)votosXpartido[count];
                p1.seats = seats[count];
                count++;
            }
            dgvSeats.Items.Refresh();
            dgvSeats.ItemsSource = lst;

        }
        public static int[] repatirVotos(int votos, int sillas)
        {
            int[] ans = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] votosperc = { 35.25, 24.75, 15.75, 14.25, 3.75, 3.25, 1.5, 0.5, 0.25, 0.25, 0.50 };
            double[] votosXpartido = new double[votosperc.Length];
            double umbral = votos * 0.03;
            int count = 0;
            for (int i = 0; i < votosperc.Length; i++)
            {
                if (votosperc[i] > 3.00)
                {
                    count++;
                }
                votosXpartido[i] = (votosperc[i] / 100) * votos;
            }
            double[,] divisiones = new double[count, sillas];
            List<double> numvotos = new List<double>();
            for (int i = 0; i < ((sillas / 2) + 1); i++)
            {
                for (int j = 0; j < count; j++)
                {
                    divisiones[j, i] = votosXpartido[j] / (i + 2);
                    numvotos.Add(votosXpartido[j] / (i + 2));
                }
            }
            for (int i = 0; i < 37; i++)
            {
                double maximo = numvotos.Max();

                for (int j = 0; j < ((sillas / 2) + 1); j++)
                {
                    for (int k = 0; k < count; k++)
                    {
                        if (divisiones[k, j] == maximo)
                        {
                            numvotos.Remove(maximo);
                            ans[k]++;
                        }

                    }
                }
            }
            ans[1] = ans[1] - 1;
            return ans;
        }
    }
}
