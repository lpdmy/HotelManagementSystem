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
            RoomInformationDAO roomInformationDAO = new RoomInformationDAO();
            roomInformationDAO.UpdateRoomInformation(new RoomInformation()
            {
                RoomID = 1,
                RoomNumber = "101",
                RoomDescription = "Single room with a beautiful view of the city.",
                RoomMaxCapacity = 1,
                RoomStatus = RoomStatus.Deleted,
                RoomPricePerDate = 100.00m,
                RoomTypeID = 1
            });
            foreach (RoomInformation r in roomInformationDAO.GetRoomInformations())
            {
                Console.WriteLine(r.RoomID + " " + r.RoomStatus);
            }
        }
    }
}
