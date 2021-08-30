using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels
{
    class TimeTableViewModel : ViewModelBase
    {
        public SchoolMSEntities1 ty = new SchoolMSEntities1();
        public TimeTable timeTable;

        public int CourseID
        {
            get { return timeTable.CourseID; }
            set
            {
                if (timeTable.CourseID != value)
                {
                    timeTable.CourseID = value;
                    OnPropertyChanged("CourseID");
                }
            }
        }
        public int SectionID

        {
            get { return timeTable.SectionID; }
            set
            {
                if (timeTable.SectionID != value)
                {
                    timeTable.SectionID = value;
                    OnPropertyChanged("SectionID");
                }
            }
        }
        public int RoomID
        {
            get { return timeTable.RoomID; }
            set
            {
                if (timeTable.RoomID != value)
                {
                    timeTable.RoomID = value;
                    OnPropertyChanged("RoomID");
                }
            }
        }
        public int YearID
        {
            get { return timeTable.YearID; }
            set
            {
                if (timeTable.YearID != value)
                {
                    timeTable.YearID = value;
                    OnPropertyChanged("YearID");
                }
            }
        }
        public int TimeTableID
        {
            get { return timeTable.TimeTableID; }
            set
            {
                if (timeTable.TimeTableID != value)
                {
                    timeTable.TimeTableID = value;
                    OnPropertyChanged("TimeTableID");
                }
            }
        }
        public string TeacherName
        {
            get { return timeTable.TeacherName; }
            set
            {
                if (timeTable.TeacherName != value)
                {
                    timeTable.TeacherName = value;
                    OnPropertyChanged("TeacherName");
                }
            }
        }
    }
}
