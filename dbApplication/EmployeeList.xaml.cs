using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using MySql.Data.MySqlClient;

namespace dbApplication
{
    /// <summary>
    /// Logika interakcji dla klasy EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : Page
    {
        public EmployeeList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// działanie po naciśnięciu przycisku odwołanie do DownloadData()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            DownloadData();
        }
        
        /// <summary>
        /// nawiązanie połączenia z bazą danych oraz pobieranie wartości z bazy danych
        /// </summary>

        public void DownloadData()
        {
            string connectionString =
            "SERVER = 127.0.0.1; DATABASE = employeeinfo; USER = root; PASSWORD = ;";

            MySqlConnection connect = new MySqlConnection(connectionString);
            try
            {
                connect.Open();

                string query = "SELECT employee.ID, employee.Name, gender.Gender, position.Position, workingtime.WorkingTime FROM employee INNER JOIN gender ON employee.Gender = gender.ID INNER JOIN position ON employee.Position = position.ID INNER JOIN workingtime ON employee.WorkingTime = workingtime.ID";

                using (MySqlCommand cmdSel = new MySqlCommand(query, connect))
                {
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                    da.Fill(dt);

                    employeeGrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Błąd połączenia z bazą danych!", "Błąd");
            }

            connect.Close();
        }

        /// <summary>
        /// przycisk odpowiadający za powrót do poprzedniej strony (EmployeeInfo).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInfo addEmployee = new EmployeeInfo();
            NavigationService.Navigate(addEmployee);
        }
    }
}
