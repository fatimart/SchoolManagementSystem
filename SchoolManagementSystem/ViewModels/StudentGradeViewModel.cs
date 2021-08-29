﻿using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels
{
    class StudentGradeViewModel : ViewModelBase
    {
        public SchoolMSEntities1 ty = new SchoolMSEntities1();
        public StudentGrade SGrades ;



        public int ID
    {
            get { return SGrades.ID; }
            set
            {
                if (SGrades.ID != value)
                {
                    SGrades.ID = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        public int CourseID
        {
            get { return SGrades.StudentID; }
            set
            {
                if (SGrades.CourseID != value)
                {
                    SGrades.CourseID = value;
                    OnPropertyChanged("CourseID");
                }
            }
        }

        public int StudentID
        {
            get { return SGrades.StudentID; }
            set
            {
                if (SGrades.StudentID != value)
                {
                    SGrades.StudentID = value;
                    OnPropertyChanged("StudentID");
                }
            }
        }

        public int Score
        {
            get { return SGrades.Score; }
            set
            {
                if (SGrades.Score != value)
                {
                    SGrades.Score = value;
                    OnPropertyChanged("Score");
                }
            }
        }

        public int Attendance
        {
            get { return SGrades.Attendance; }
            set
            {
                if (SGrades.Attendance != value)
                {
                    SGrades.Attendance = value;
                    OnPropertyChanged("Attendance");
                }
            }
        }
        public bool Done
        {
            get { return SGrades.Done; }
            set
            {
                if (SGrades.Done != value)
                {
                    SGrades.Done = value;
                    OnPropertyChanged("Done");
                }
            }
        }
        public int yearID
        {
            get { return SGrades.yearID; }
            set
            {
                if (SGrades.yearID != value)
                {
                    SGrades.yearID = value;
                    OnPropertyChanged("yearID");
                }
            }
        }

        public void AddStudentGrade(int ID, int CourseID, int StudentID, int Score, int Attendance, bool Done, int yearID)
        {

            StudentGrade SGrade = new StudentGrade();
            SGrade.ID = ID;
            SGrade.CourseID = CourseID;
            SGrade.StudentID = StudentID;
            SGrade.Score = Score;
            SGrade.Attendance = Attendance;
            SGrade.Done = Done;
            SGrade.yearID = yearID;

            ty.StudentGrades.Add(SGrade);
            ty.SaveChanges();

        }


        public void UpdateStudentGrade(int ID, int CourseID, int StudentID, int Score, int Attendance, bool Done, int yearID)
        {

            StudentGrade updateSGrade = (from m in ty.StudentGrades where m.ID == ID select m).Single();
            updateSGrade.ID = ID;
            updateSGrade.CourseID = CourseID;
            updateSGrade.StudentID = StudentID;
            updateSGrade.Score = Score;
            updateSGrade.Attendance = Attendance;
            updateSGrade.Done = Done;
            updateSGrade.yearID = yearID;
            ty.SaveChanges();

        }

        public void DeleteSection(int ID)
        {

            var deleteStudentGrade = ty.StudentGrades.Where(m => m.ID == ID).Single();
            ty.StudentGrades.Remove(deleteStudentGrade);
            ty.SaveChanges();

        }




    }
}
