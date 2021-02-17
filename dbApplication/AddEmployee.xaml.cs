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

        /// <summary>
        /// przycisk odpowiadający za przeniesienie do strony EmployeeList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            EmployeeList employeeList = new EmployeeList();
            NavigationService.Navigate(employeeList);
        }

        /// <summary>
        /// działanie po naciśnięciu przycisku odwołanie do AddEmpl()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void AddEmpl_Click(object sender, RoutedEventArgs e)
        {
            AddEmpl();
        }

        /// <summary>
        /// pobiera wartości z pól TextBox i ContentBox ze strony "AddEmployee" oraz zamiana z tekstu na odpowiadającą mu wartość liczbową 
        /// </summary>
        
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

            ///nawiązanie połączenia z bazą danych employeeinfo oraz wstawnienie watrości do bazy danych
            string connectionString =
            "SERVER = 'localhost'; DATABASE = 'employeeinfo'; USER = 'root'; PASSWORD = '';";

            MySqlConnection connect = new MySqlConnection(connectionString);

            try
            {
                connect.Open();

                string query = $"INSERT INTO `employee`(`Name`, `Gender`, `WorkingTime`, `Position`) VALUES ('{fullname}', {genderID}, {workingTimeID}, {positionID});";

                MySqlCommand cmd = new MySqlCommand(query, connect);
                
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Poprawnie dodano pracownika.", "Dodano pracownika");
                }
                else
                {
                    MessageBox.Show("Błąd dodawania do bazy danych!", "Błąd");
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
