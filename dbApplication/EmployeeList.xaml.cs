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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DownloadData();
        }

        public void DownloadData()
        {
            string connection =
            "SERVER = localhost; DATABASE = employeeinfo; UID = root@localhost; PASSWORD ='';";

            string query = "SELECT Name FROM Employee";

            MySqlConnection connect = new MySqlConnection(connection);
            try
            {
                connect.Open();

                using (MySqlCommand cmdSel = new MySqlCommand(query, connect))
                {
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                    da.Fill(dt);

                    dataGrid1.ItemsSource = dt.DefaultView;
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Błąd połączenia z bazą danych!", "Błąd");
            }

            connect.Close();
        }

    }
}
