using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels
{
    class YearViewModel : ViewModelBase
    {
        public SchoolMSEntities1 ty = new SchoolMSEntities1();
        public Year year;

     
        public string YearNum
        {
            get { return year.YearNum; }
            set
            {
                if (year.YearNum != value)
                {
                    year.YearNum = value;
                    OnPropertyChanged("YearNum");
                }
            }
        }
         public int YearID
        {
            get { return year.YearID; }
            set
            {
                if (year.YearID != value)
                {
                    year.YearID = value;
                    OnPropertyChanged("YearID");
                }
            }
        }

        public void AddYear(int YearID, string YearNum)
        {

            Year year = new Year();
            year.YearID = YearID;
            year.YearNum = YearNum;


            ty.Years.Add(year);
            ty.SaveChanges();

        }


        public void UpdateStudentGrade(int YearID, string YearNum)
        {

            Year updateYears = (from m in ty.Years where m.YearID == YearID select m).Single();
            updateYears.YearID = YearID;
            updateYears.YearNum = YearNum;

            ty.SaveChanges();

        }

        public void DeleteYear(int YearID)
        {

            var deleteYears = ty.Years.Where(m => m.YearID == YearID).Single();
            ty.Years.Remove(deleteYears);
            ty.SaveChanges();

        }



    }
}
