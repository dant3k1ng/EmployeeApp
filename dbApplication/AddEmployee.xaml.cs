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
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;

namespace dbApplication
{
    /// <summary>
    /// Logika interakcji dla klasy EmployeeInfo.xaml
    /// </summary>
    public partial class EmployeeInfo : Page
    {
        public EmployeeInfo()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            EmployeeList employeeList = new EmployeeList();
            NavigationService.Navigate(employeeList);
        }

        private void AddEmpl_Click(object sender, RoutedEventArgs e)
        {
            AddEmpl();
        }

        public void AddEmpl()
        {
            string fullname = nameAndSurname.Text;
            
            string gender = genderBox.Text;
            int genderID = 1;
            if (gender == "Male")
                genderID = 1;
            else if (gender == "Female")
                genderID = 2;

            string workingTime = workingTimeBox.Text;
            int workingTimeID = 1;
            if (workingTime == "Fulltime")
                workingTimeID = 1;
            else if (workingTime == "Parttime")
                workingTimeID = 2;
            else if (workingTime == "Practice")
                workingTimeID = 3;

            string position = positionBox.Text;
            int positionID = 1;
            if (position == "Boss")
                positionID = 1;
            else if (position == "Programmer")
                positionID = 2;
            else if (position == "Trainee")
                positionID = 3;

            string connection = "SERVER = 127.0.0.1; DATABASE = employeeinfo; UID = root; PASSWORD = '';";

            MySqlConnection connect = new MySqlConnection(connection);
            try
            {
                string query = $"INSERT INTO employee VALUES ({null}, {fullname},{genderID},{workingTimeID},{positionID});";
                connect.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connect))
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Poprawnie dodano pracownika.", "Dodano pracownika");
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
