﻿using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolManagementSystem.ViewModels
{
    class StudentListViewModel : ViewModelBase
    {
        public User user;

        private SchoolMSEntities1 ty = new SchoolMSEntities1();
        public ObservableCollection<User> AllUsers { get; private set; }

/**        public ObservableCollection<User> AllUsers
        {
            get
            {
                return _allStudents;
            }
            set
            {
                _allStudents = value;
                OnPropertyChanged("AllUsers");
            }
        }**/



        public int UserID
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

        public string UserName
        {
            get { return user.UserName; }
            set
            {
                if (user.UserName != value)
                {
                    user.UserName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        public string Name
        {
            get { return user.Name; }
            set
            {
                if (user.Name != value)
                {
                    user.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Email
        {
            get { return user.Email; }
            set
            {
                if (user.Email != value)
                {
                    user.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public decimal CPR
        {
            get { return user.CPR; }
            set
            {
                if (user.CPR != value)
                {
                    user.CPR = value;
                    OnPropertyChanged("CPR");
                }
            }
        }

        public string Address
        {
            get { return user.Address; }
            set
            {
                if (user.Address != value)
                {
                    user.Address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        public string Type
        {
            get { return user.Type; }
            set
            {
                if (user.Type != value)
                {
                    user.Type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public string Password
        {
            get { return user.Password; }
            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string ContactNo
        {
            get { return user.ContactNo; }
            set
            {
                if (user.ContactNo != value)
                {
                    user.ContactNo = value;
                    OnPropertyChanged("ContactNo");
                }
            }
        }

        public DateTime DOB
        {
            get { return user.DOB; }
            set
            {
                if (user.DOB != value)
                {
                    user.DOB = value;
                    OnPropertyChanged("dob");
                }
            }
        }

        /**public StudentListViewModel ()
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
        }**/

        public StudentListViewModel ()
        {

            GetAll();
            //AllUsers = new ObservableCollection<User>();

        }



        public List<User> GetAll1 ()
        {
            return ty.Users.Where(m => m.Type == "Student").ToList();
        }

        public void GetAll ()
        {
            AllUsers = new ObservableCollection<User>();
            GetAll1().ForEach(data => AllUsers.Add(new User()
            {
                UserID = Convert.ToInt32(data.UserID),
                UserName = data.UserName,
                Name = data.Name,
                Email = data.Email,
                CPR = Convert.ToDecimal(data.CPR),
                Address = data.Address,
                DOB = Convert.ToDateTime(data.DOB),
                Type = data.Type,
                Password = data.Password,
                ContactNo = data.ContactNo

            }));

            //return AllUsers;

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
                user1.Type = "Student";
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

        public void UpdateUser ( int userID, string name, string email, decimal cpr, string address, DateTime dob, string password, string contactNo )
        {
            if (CheckIfUserExists(userID))
            {
                try
                {


                    User updateUser = (from m in ty.Users
                                       where m.UserID == userID
                                       select m).Single();

                    updateUser.Name = name;
                    updateUser.Email = email;
                    updateUser.CPR = cpr;
                    updateUser.Address = address;
                    updateUser.DOB = dob;
                    updateUser.Type = "Student";
                    updateUser.Password = password;
                    updateUser.ContactNo = contactNo;

                    ty.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    GetAll();
                    ResetData();
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

        public void ResetData ()
        {
            User user1 = new User();

            user1.Name = string.Empty;
            user1.UserID = 0;
            user1.UserName = string.Empty;
            user1.Email = string.Empty;
            user1.CPR = 0;
            user1.Address = string.Empty;
            user1.Type = "Student";
            user1.Password = string.Empty;
            user1.ContactNo = string.Empty;
        }

    }


}