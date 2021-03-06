using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
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
    /// Interaction logic for RegisterUsers.xaml
    /// </summary>
    public partial class RegisterUsers : Window
    {
        

        private readonly UserViewModel _viewModel;
        SchoolMSEntities1 dataEntities = new SchoolMSEntities1();
        public RegisterUsers ()
        {
            InitializeComponent();
            _viewModel = new UserViewModel();

            // The DataContext serves as the starting point of Binding Paths
            DataContext = _viewModel;
        }


        private void Window_Loaded ( object sender, RoutedEventArgs e )
        {

            SchoolManagementSystem.SchoolMSDataSet schoolMSDataSet = ((SchoolManagementSystem.SchoolMSDataSet)(this.FindResource("schoolMSDataSet")));
            // Load data into the table Users. You can modify this code as needed.
            SchoolManagementSystem.SchoolMSDataSetTableAdapters.UsersTableAdapter schoolMSDataSetUsersTableAdapter = new SchoolManagementSystem.SchoolMSDataSetTableAdapters.UsersTableAdapter();
            schoolMSDataSetUsersTableAdapter.Fill(schoolMSDataSet.Users);

            //MARK: to not have them in the textboX
            //System.Windows.Data.CollectionViewSource usersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("usersViewSource")));
            //usersViewSource.View.MoveCurrentToFirst();

        }

        public void Load ()
        {
            Clear();
            SchoolManagementSystem.SchoolMSDataSet schoolMSDataSet = ((SchoolManagementSystem.SchoolMSDataSet)(this.FindResource("schoolMSDataSet")));
            // Load data into the table Users. You can modify this code as needed.
            SchoolMSDataSetTableAdapters.UsersTableAdapter schoolMSDataSetUsersTableAdapter = new SchoolMSDataSetTableAdapters.UsersTableAdapter();
            schoolMSDataSetUsersTableAdapter.Fill(schoolMSDataSet.Users);
        }

        private void AddNewStudent_Click ( object sender, RoutedEventArgs e )
        {
            _viewModel.InsertUser(
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
            _viewModel.UpdateUser(
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

        private void AddNewTeacher_Click ( object sender, RoutedEventArgs e )
        {
            _viewModel.InsertUser(
                                      //Convert.ToInt32(tuserIDTextBox.Text.Trim()),
                                      tuserNameTextBox.Text.Trim(),
                                      tnameTextBox.Text.Trim(),
                                      temailTextBox.Text.Trim(),
                                      Convert.ToDecimal(tcPRTextBox.Text),
                                      taddressTextBox.Text.Trim(),
                                      Convert.ToDateTime(tdOBDatePicker.Text),
                                      //ttypeTextBox.Text.Trim(),
                                      tpasswordTextBox.Text.Trim(),
                                      tcontactNoTextBox.Text.Trim()
                                  );
            Load();
        }


        private void UpdateTeacher_Click ( object sender, RoutedEventArgs e )
        {
            _viewModel.UpdateUser(
                                      Convert.ToInt32(tuserIDTextBox.Text.Trim()),
                                      tuserNameTextBox.Text.Trim(),
                                      tnameTextBox.Text.Trim(),
                                      temailTextBox.Text.Trim(),
                                      Convert.ToDecimal(tcPRTextBox.Text),
                                      taddressTextBox.Text.Trim(),
                                      Convert.ToDateTime(tdOBDatePicker.Text),
                                      //ttypeTextBox.Text.Trim(),
                                      tpasswordTextBox.Text.Trim(),
                                      tcontactNoTextBox.Text.Trim()
                      );
            Load();
        }

        public void Clear()
        {
            tuserIDTextBox.Text = "";
            tuserNameTextBox.Text = "";
            tnameTextBox.Text = "";
            temailTextBox.Text = "";
            tcPRTextBox.Text = "";
            taddressTextBox.Text = "";
            tdOBDatePicker.Text = "";
            ttypeTextBox.Text = "";
            tpasswordTextBox.Text = "";
            tcontactNoTextBox.Text = "";
        }

        private void usersDataGrid_SelectionChanged ( object sender, SelectionChangedEventArgs e )
        {

        }

        /**void signUpNewUser ()
{

   try
   {
       SqlConnection con = new SqlConnection(strcon);
       //check if the connec is opened or not
       if (con.State == ConnectionState.Closed)
       {
           con.Open();
       }


       //query
       SqlCommand cmd = new SqlCommand("INSERT INTO Users(UserName,Name,Email,CPR,Address,DOB,Type,Password,ContactNo) VALUES " +
           "(@UserName,@Name,@Email,@CPR,@Address,@DOB,@Type,@Password,@ContactNo)", con);                //clear enterstring Trim

       cmd.Parameters.AddWithValue("@UserName", TextBox3.Text.Trim());
       cmd.Parameters.AddWithValue("@Name", TextBox5.Text.Trim());
       cmd.Parameters.AddWithValue("@Email", TextBox4.Text.Trim());
       cmd.Parameters.AddWithValue("@CPR", TextBox6.Text.Trim());
       cmd.Parameters.AddWithValue("@Address", DropDownList1.SelectedItem.Value);
       cmd.Parameters.AddWithValue("@DOB", TextBox2.Text.Trim());
       cmd.Parameters.AddWithValue("@Type", TextBox7.Text.Trim());
       cmd.Parameters.AddWithValue("@Password", TextBox1.Text.Trim());
       cmd.Parameters.AddWithValue("@ContactNo", TextBox8.Text.Trim());
       
       cmd.ExecuteNonQuery();
       con.Close();

       MessageBox.Show(" User Have been Registered Successfullty");
   }
   catch (Exception ex)
   {
       MessageBox.Show(ex.Message);

   }
}**/
    }
}