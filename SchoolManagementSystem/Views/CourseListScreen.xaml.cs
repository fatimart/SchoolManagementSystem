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
using System.Data.SqlClient;
using SchoolManagementSystem;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for CourseListScreen.xaml
    /// </summary>
    public partial class CourseListScreen : Window
    {
        CourseViewModel course = new CourseViewModel();
        public CourseListScreen()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SchoolManagementSystem.SchoolMSDataSet schoolMSDataSet = ((SchoolManagementSystem.SchoolMSDataSet)(this.FindResource("schoolMSDataSet")));
            // Load data into the table Course. You can modify this code as needed.
            SchoolManagementSystem.SchoolMSDataSetTableAdapters.CourseTableAdapter schoolMSDataSetCourseTableAdapter = new SchoolManagementSystem.SchoolMSDataSetTableAdapters.CourseTableAdapter();
            schoolMSDataSetCourseTableAdapter.Fill(schoolMSDataSet.Course);



        }
        public void Load()
        {
            SchoolManagementSystem.SchoolMSDataSet schoolMSDataSet = ((SchoolManagementSystem.SchoolMSDataSet)(this.FindResource("schoolMSDataSet")));
            // Load data into the table Course. You can modify this code as needed.
            SchoolManagementSystem.SchoolMSDataSetTableAdapters.CourseTableAdapter schoolMSDataSetCourseTableAdapter = new SchoolManagementSystem.SchoolMSDataSetTableAdapters.CourseTableAdapter();
            schoolMSDataSetCourseTableAdapter.Fill(schoolMSDataSet.Course);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //   System.Windows.Data.CollectionViewSource courseViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("courseViewSource")));
            //  courseViewSource.View.MoveCurrentToFirst();

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            course.AddCourse(courseNameTextBox.Text.Trim(), courseCodeTextBox.Text.Trim(), descriptionTextBox.Text.Trim(), Convert.ToDateTime(examDateDatePicker.Text), Convert.ToInt32(sectionIDTextBox.Text.Trim()));
            Load();

            /* SchoolMSEntities1 ty = new SchoolMSEntities1();
             Course course = new Course();
             course.CourseName = courseNameTextBox.Text.Trim();
             course.CourseCode = courseCodeTextBox.Text.Trim();
             course.Description = descriptionTextBox.Text.Trim();
             course.ExamDate = Convert.ToDateTime(examDateDatePicker.Text);
             course.SectionID = Convert.ToInt32(sectionIDTextBox.Text.Trim());

             ty.Courses.Add(course);
             ty.SaveChanges(); */
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            course.Clear();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            course.UpdateCourse(Convert.ToInt32(courseIDTextBox.Text.Trim()), courseNameTextBox.Text.Trim(), courseCodeTextBox.Text.Trim(), descriptionTextBox.Text.Trim(), Convert.ToDateTime(examDateDatePicker.Text), Convert.ToInt32(sectionIDTextBox.Text.Trim()));
            Load();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            if (course.CheckCourseID(Convert.ToInt32(courseIDTextBox.Text.Trim())))
            {

                course.DeleteCourse(Convert.ToInt32(courseIDTextBox.Text.Trim()));
                Load();

            }


            else
            {
                MessageBox.Show("ID not existed");
            }

        }




    }
}
