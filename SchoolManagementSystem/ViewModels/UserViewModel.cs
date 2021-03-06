using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolManagementSystem.ViewModels
{
    class UserViewModel : ViewModelBase
    {
        public User user;
        public List<User> AllUsers { get; private set; }

        private SchoolMSEntities1 ty = new SchoolMSEntities1();

        public static User session;

        //ViewModel
        public UserViewModel ()
        {
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(strcon))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT TOP 1 * FROM Users;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = new User
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            UserName = reader["UserName"].ToString(),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            CPR = Convert.ToInt32(reader["CPR"]),
                            Address = reader["Address"].ToString(),
                            DOB = Convert.ToDateTime(reader["DOB"]),
                            Type = reader["Type"].ToString(),
                            Password = reader["Password"].ToString(),
                            ContactNo = reader["ContactNo"].ToString(),
                        };
                    }
                }
                reader.Close();
            }

        }

        //Functions 


        //MARK: Login Function
        public bool login ( string username, string password )
        {
            User user2 = new User();
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    SqlCommand command = new SqlCommand(
                      "select * from Users where UserName='" + username + "' AND Password='" + password + "'", connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user2 = new User
                            {
                                UserName = reader["UserName"].ToString(),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                CPR = Convert.ToInt32(reader["CPR"]),
                                Address = reader["Address"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Type = reader["Type"].ToString(),
                                Password = reader["Password"].ToString(),
                                ContactNo = reader["ContactNo"].ToString(),

                            };
                            Application.Current.Resources["userref"] = user2;
                            Application.Current.Resources["UserName"] = user2.UserName;
                            Application.Current.Resources["Name"] = user2.Name;
                            Application.Current.Resources["Type"] = user.Type;
                        }

                        reader.Close();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect.");
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Sayed function get list of all users
        public List<User> getUsers ( string username, string pass )
        {
            List<User> users = new List<User>();
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(strcon))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM Users;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserName = reader["UserName"].ToString(),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            CPR = Convert.ToInt32(reader["CPR"]),
                            Address = reader["Address"].ToString(),
                            //DOB = Convert.ToDateTime(DateTime.ParseExact(, "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                            Type = reader["Type"].ToString(),
                            Password = reader["Password"].ToString(),
                            ContactNo = reader["ContactNo"].ToString(),
                        });
                    }
                }
                reader.Close();
            }
            return users;

        }


        public void InsertUser (string username, string name, string email, decimal cpr, string address, DateTime dob, string password, string contactNo )
        {
            try
            {
                User user1 = new User();

                //user1.UserID = userID;

                user1.UserName = username;
                user1.Name = name;
                user1.Email = email;
                user1.CPR = cpr;
                user1.Address = address;
                user1.DOB = dob;
                user1.Type = "user";
                user1.Password = password;
                user1.ContactNo = contactNo;

                ty.Users.Add(user1);
                ty.SaveChanges();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void UpdateUser ( int userID, string username, string name, string email, decimal cpr, string address, DateTime dob, string password, string contactNo )
        {
            if (checkIfMemberExists(userID))
            {
                try
                {


                    User updateUser = (from m in ty.Users
                                       where m.UserID == userID
                                       select m).Single();

                    updateUser.UserName = username;
                    updateUser.Name = name;
                    updateUser.Email = email;
                    updateUser.CPR = cpr;
                    updateUser.Address = address;
                    updateUser.DOB = dob;
                    updateUser.Type = "user";
                    updateUser.Password = password;
                    updateUser.ContactNo = contactNo;

                    ty.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid user Id");

            }
        }


        bool checkIfMemberExists (int userID)
        {
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Users where UserID='" + userID.ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        }


        //MARK: Get A list of all users
        /**public List<User> getAllUsers ()
        {
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(strcon))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM Users;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllUsers.Add(new User()
                    {
                        UserName = reader["UserName"].ToString(),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        CPR = Convert.ToInt32(reader["CPR"]),
                        Address = reader["Address"].ToString(),
                        //DOB = 
                        Type = reader["Type"].ToString(),
                        Password = reader["Password"].ToString(),
                        ContactNo = reader["ContactNo"].ToString(),

                    });
                }

                reader.Close();
                return AllUsers;
            }
        }
        
         * 
         * 
         * 
         * 
         * 
         * /**public int UserID
        {
            get { return user.UserID; }
            set
            {
                if (user.UserID != value)
                {
                    user.UserID = value;
                    OnPropertyChanged("UserID");
                }
            }
        }

        //public string UserName
        //{
        //    get { return user.UserName; }
        //    set
        //    {
        //        if (user.UserName != value)
        //        {
        //            user.UserName = value;
        //            OnPropertyChanged("UserName");
        //        }
        //    }
        //}

        //public string Name
        //{
        //    get { return user.Name; }
        //    set
        //    {
        //        if (user.Name != value)
        //        {
        //            user.Name = value;
        //            OnPropertyChanged("Name");
        //        }
        //    }
        //}

        //public string Email
        //{
        //    get { return user.Email; }
        //    set
        //    {
        //        if (user.Email != value)
        //        {
        //            user.Email = value;
        //            OnPropertyChanged("Email");
        //        }
        //    }
        //}

        //public decimal CPR
        //{
        //    get { return user.CPR; }
        //    set
        //    {
        //        if (user.CPR != value)
        //        {
        //            user.CPR = value;
        //            OnPropertyChanged("CPR");
        //        }
        //    }
        //}

        //public string Address
        //{
        //    get { return user.Address; }
        //    set
        //    {
        //        if (user.Address != value)
        //        {
        //            user.Address = value;
        //            OnPropertyChanged("Address");
        //        }
        //    }
        //}

        //public string Type
        //{
        //    get { return user.Type; }
        //    set
        //    {
        //        if (user.Type != value)
        //        {
        //            user.Type = value;
        //            OnPropertyChanged("Type");
        //        }
        //    }
        //}

        //public string Password
        //{
        //    get { return user.Password; }
        //    set
        //    {
        //        if (user.Password != value)
        //        {
        //            user.Password = value;
        //            OnPropertyChanged("Password");
        //        }
        //    }
        //}

        //public string ContactNo
        //{
        //    get { return user.ContactNo; }
        //    set
        //    {
        //        if (user.ContactNo != value)
        //        {
        //            user.ContactNo = value;
        //            OnPropertyChanged("ContactNo");
        //        }
        //    }
        //}

        //public DateTime DOB
        //{
        //    get { return user.DOB; }
        //    set
        //    {
        //        if (user.DOB != value)
        //        {
        //            user.DOB = value;
        //            OnPropertyChanged("DOB");
        //        }
        //    }
        //}
          

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - user.DOB.Year;
                if (user.DOB > today.AddYears(-age)) age--;
                return age;
            }
        }
        **/

    }
