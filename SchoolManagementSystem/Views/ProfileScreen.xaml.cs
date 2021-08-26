﻿using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;
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
using System.Windows.Shapes;

namespace SchoolManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for ProfileScreen.xaml
    /// </summary>
    public partial class ProfileScreen : Window
    {
        EditProfileViewModel editView = new EditProfileViewModel();

        public ProfileScreen ()
        {
            InitializeComponent();
            DataContext = editView.user;
        }


        private void Window_Loaded ( object sender, RoutedEventArgs e )
        {
            string type = UserViewModel.userSession.Type.ToString();

            if (type == "Admin" || type == "Admin")
            {
                student_list.Visibility = Visibility.Hidden;
            }
        }

        private void logOut_Click ( object sender, RoutedEventArgs e )
        {
            User user = new User();
            UserViewModel.userSession = user;


            MessageBox.Show(UserViewModel.userSession.UserID.ToString());
            LoginScreen dashboard = new LoginScreen();
            dashboard.Show();
            this.Close();
        }

        private void student_list_Click ( object sender, RoutedEventArgs e )
        {
            StudentsListScreen dashboard = new StudentsListScreen();
            dashboard.Show();
        }


        private void Button_Click ( object sender, RoutedEventArgs e )
        {
            RegisterUsers dashboard = new RegisterUsers();
            dashboard.Show();
        }
    }
}
