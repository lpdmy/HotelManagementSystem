using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<RoomInformation> list = RoomInformationDAO.Instance.GetRoomInformations();
            foreach (RoomInformation room in list)
            {
                Console.WriteLine(room.RoomID);
            }
            RoomInformationDAO.Instance.SaveRoomInformation(new RoomInformation()
            {
                RoomID = 100,
                RoomNumber = "100",
                RoomMaxCapacity = 100,
                RoomDescription = "",
                RoomType = new RoomType() { },
                RoomStatus = RoomStatus.Active,
                RoomPricePerDate = 100,
                RoomTypeID = 1,
                
            });
            List<RoomInformation> list1 = RoomInformationDAO.Instance.GetRoomInformations();
            Console.WriteLine("New");
            foreach (RoomInformation room in list1)
            {
                Console.WriteLine(room.RoomID);
            }
        }
    }
}
