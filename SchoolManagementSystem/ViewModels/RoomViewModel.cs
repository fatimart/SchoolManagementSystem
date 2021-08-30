using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels
{
    class RoomViewModel : ViewModelBase
    {
        public SchoolMSEntities1 ty = new SchoolMSEntities1();
        public Room Room;

        public int RoomID
        {
            get { return Room.RoomID; }
            set
            {
                if (Room.RoomID != value)
                {
                    Room.RoomID = value;
                    OnPropertyChanged("RoomID");
                }
            }
        }
        public string RoomNum
        {
            get { return Room.RoomNum; }
            set
            {
                if (Room.RoomNum != value)
                {
                    Room.RoomNum = value;
                    OnPropertyChanged("RoomNum");
                }
            }
        }




    }
}
