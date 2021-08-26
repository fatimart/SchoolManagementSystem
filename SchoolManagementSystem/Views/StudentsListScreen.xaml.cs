using SchoolManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace SchoolManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for StudentsListScreen.xaml
    /// </summary>
    public partial class StudentsListScreen : Window
    {
        StudentListViewModel _userViewModel = new StudentListViewModel();

        public StudentsListScreen ()
        {
            InitializeComponent();
            DataContext = _userViewModel.user;
            FillDataGrid();
        }

        public void Load()
        {
            usersDataGrid.Items.Refresh();
           

        }

        private void Window_Loaded ( object sender, RoutedEventArgs e )
        {

            //SchoolManagementSystem.SchoolMSDataSet schoolMSDataSet = ((SchoolManagementSystem.SchoolMSDataSet)(this.FindResource("schoolMSDataSet")));

            // Load data into the table Users. You can modify this code as needed.
            //SchoolManagementSystem.SchoolMSDataSetTableAdapters.UsersTableAdapter schoolMSDataSetUsersTableAdapter = new SchoolManagementSystem.SchoolMSDataSetTableAdapters.UsersTableAdapter();
            // schoolMSDataSetUsersTableAdapter.Fill(schoolMSDataSet.Users);

            usersDataGrid.Items.Refresh();

        }

        private void FillDataGrid ()

        {
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(strcon))
            {
                SqlCommand command = new SqlCommand(
                     "select * from Users where Type='" + "student" + "'", connection);
                connection.Open();

                SqlDataAdapter sda = new SqlDataAdapter(command);

                DataTable dt = new DataTable("Users");

                sda.Fill(dt);

                usersDataGrid.ItemsSource = dt.DefaultView;

             
            }

        }

        private void AddNewStudent_Click ( object sender, RoutedEventArgs e )
        {
            _userViewModel.InsertUser(
                                      //Convert.ToInt32(userIDTextBox.Text.Trim()),
                                      userNameTextBox.Text.Trim(),
                                      nameTextBox.Text.Trim(),
                                      emailTextBox.Text.Trim(),
                                      Convert.ToDecimal(cPRTextBox.Text),
                                      addressTextBox.Text.Trim(),
                                      Convert.ToDateTime(dOBDatePicker.Text),
                                      passwordTextBox.Text.Trim(),
                                      contactNoTextBox.Text.Trim()
                                  );

            Load();
        }

        private void UpdateStudent_Click ( object sender, RoutedEventArgs e )
        {
            _userViewModel.UpdateUser(
                                      Convert.ToInt32(userIDTextBox.Text.Trim()),
                                      userNameTextBox.Text.Trim(),
                                      nameTextBox.Text.Trim(),
                                      emailTextBox.Text.Trim(),
                                      Convert.ToDecimal(cPRTextBox.Text),
                                      addressTextBox.Text.Trim(),
                                      Convert.ToDateTime(dOBDatePicker.Text),
                                      passwordTextBox.Text.Trim(),
                                      contactNoTextBox.Text.Trim()
                                  );
            Load();
        }

       

        public void Clear ()
        {
            userIDTextBox.Text = "";
            userNameTextBox.Text = "";
            nameTextBox.Text = "";
            emailTextBox.Text = "";
            cPRTextBox.Text = "";
            addressTextBox.Text = "";
            dOBDatePicker.Text = "";
            passwordTextBox.Text = "";
            contactNoTextBox.Text = "";
        }

        private void DeleteStudent_Click ( object sender, RoutedEventArgs e )
        {
            _userViewModel.DeleteUser(Convert.ToInt32(userIDTextBox.Text.Trim()));
            Load();
        }


    }
}
