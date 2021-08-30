using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
            DataContext = _userViewModel;
        }

        public void Load()
        {

            usersDataGrid.Items.Refresh();           

        }

        private void Window_Loaded ( object sender, RoutedEventArgs e )
        {
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

                usersDataGrid.Items.Refresh();

               

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
           

            // _userViewModel.ResetData();

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

      
        private void Button_Click_1 ( object sender, RoutedEventArgs e )
        {

        }

        private void usersDataGrid_SelectionChanged ( object sender, SelectionChangedEventArgs e )
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;

            if(row_selected != null)
            {
                userIDTextBox.Text = row_selected["UserID"].ToString();
                userNameTextBox.Text = row_selected["UserName"].ToString(); 
                nameTextBox.Text = row_selected["Name"].ToString();
                emailTextBox.Text = row_selected["Email"].ToString();
                cPRTextBox.Text = row_selected["CPR"].ToString();
                addressTextBox.Text = row_selected["Address"].ToString();
                dOBDatePicker.Text = row_selected["DOB"].ToString();
                passwordTextBox.Text = row_selected["Password"].ToString();
                contactNoTextBox.Text = row_selected["ContactNo"].ToString();
            }
        }

        private void Reset_Click ( object sender, RoutedEventArgs e )
        {
           /** foreach (var user in _userViewModel.GetAll())
            {
                MessageBox.Show(user.Address);

            }**/
        }
    }
}