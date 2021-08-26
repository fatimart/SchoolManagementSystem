using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolManagementSystem.ViewModels
{
    class StudentListViewModel
    {
        public User user;

        private SchoolMSEntities1 ty = new SchoolMSEntities1();

        public StudentListViewModel ()
        {
            
                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    SqlCommand command = new SqlCommand(
                         "select * from Users where Type='" + "Student" + "'", connection);
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
                                CPR = Convert.ToDecimal(reader["CPR"]),
                                Address = reader["Address"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Type = reader["Type"].ToString(),
                                Password = reader["Password"].ToString(),
                                ContactNo = reader["ContactNo"].ToString(),
                            };
                        }
                    }
                    //MessageBox.Show("edit" + Application.Current.Resources["UserName"].ToString());
                    reader.Close();
                

            }
        }


        public void InsertUser ( string username, string name, string email, decimal cpr, string address, DateTime dob, string password, string contactNo )
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

        public void getUserByID ( int userID )
        {
            try
            {
                var query = from u in ty.Users
                            where u.UserID == userID
                            select u;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateUser ( int userID, string username, string name, string email, decimal cpr, string address, DateTime dob, string password, string contactNo )
        {
            if (CheckIfUserExists(userID))
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

        public void DeleteUser ( int userID )
        {
            if (CheckIfUserExists(userID))
            {
                try

                {

                    var deleteUser = ty.Users.Where(m => m.UserID == userID).Single();
                    ty.Users.Remove(deleteUser);
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

        public bool CheckIfUserExists ( int userID )
        {
            try
            {
                var user = ty.Users.Where(m => m.UserID == userID).Single();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;

        }

    }


}
