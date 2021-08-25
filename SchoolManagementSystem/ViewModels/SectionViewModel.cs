using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels
{
    class SectionViewModel : ViewModelBase
    {
        public SchoolMSEntities1 ty = new SchoolMSEntities1();
        public Section Section;

        public int SectionID
        {
            get { return Section.SectionID; }
            set
            {
                if (Section.SectionID != value)
                {
                    Section.SectionID = value;
                    OnPropertyChanged("SectionID");
                }
            }
        }
        public byte SectionNum
        {
            get { return Section.SectionNum; }
            set
            {
                if (Section.SectionNum != value)
                {
                    Section.SectionNum = value;
                    OnPropertyChanged("SectionNum");
                }
            }
        }
        public int CourseID
        {
            get { return Section.CourseID; }
            set
            {
                if (Section.CourseID != value)
                {
                    Section.CourseID = value;
                    OnPropertyChanged("CourseID");
                }
            }
        }
        public int RoomID
        {
            get { return Section.RoomID; }
            set
            {
                if (Section.RoomID != value)
                {
                    Section.RoomID = value;
                    OnPropertyChanged("RoomID");
                }
            }
        }




    }
}
