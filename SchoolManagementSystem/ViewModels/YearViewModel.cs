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


    
    }
}
