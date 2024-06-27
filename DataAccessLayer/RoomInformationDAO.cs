using BusinessObjects;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class RoomInformationDAO : SingletonBase<RoomInformationDAO>
    {
        List<RoomInformation> list = new List<RoomInformation>();
        public RoomInformationDAO() {
         list.AddRange(new List<RoomInformation> {


                new RoomInformation
                {
                    RoomID = 1,
                    RoomNumber = "101",
                    RoomDescription = "Single room with a beautiful view of the city.",
                    RoomMaxCapacity = 1,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 100.00m,
                    RoomTypeID = 1
                },
                new RoomInformation
                {
                    RoomID = 2,
                    RoomNumber = "102",
                    RoomDescription = "Double room with garden access.",
                    RoomMaxCapacity = 2,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 150.00m,
                    RoomTypeID = 2
                },
                new RoomInformation
                {
                    RoomID = 3,
                    RoomNumber = "103",
                    RoomDescription = "Suite with a private balcony.",
                    RoomMaxCapacity = 4,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 250.00m,
                    RoomTypeID = 3
                },
                new RoomInformation
                {
                    RoomID = 4,
                    RoomNumber = "104",
                    RoomDescription = "Economy single room.",
                    RoomMaxCapacity = 1,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 80.00m,
                    RoomTypeID = 1
                },
                new RoomInformation
                {
                    RoomID = 5,
                    RoomNumber = "105",
                    RoomDescription = "Luxury double room with ocean view.",
                    RoomMaxCapacity = 2,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 300.00m,
                    RoomTypeID = 2
                },
                new RoomInformation
                {
                    RoomID = 6,
                    RoomNumber = "106",
                    RoomDescription = "Family room with kitchenette.",
                    RoomMaxCapacity = 5,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 200.00m,
                    RoomTypeID = 4
                },
                new RoomInformation
                {
                    RoomID = 7,
                    RoomNumber = "107",
                    RoomDescription = "Single room with a queen-sized bed.",
                    RoomMaxCapacity = 1,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 120.00m,
                    RoomTypeID = 1
                },
                new RoomInformation
                {
                    RoomID = 8,
                    RoomNumber = "108",
                    RoomDescription = "Double room with two single beds.",
                    RoomMaxCapacity = 2,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 130.00m,
                    RoomTypeID = 2
                },
                new RoomInformation
                {
                    RoomID = 9,
                    RoomNumber = "109",
                    RoomDescription = "Single room with workspace.",
                    RoomMaxCapacity = 1,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 110.00m,
                    RoomTypeID = 1
                },
                new RoomInformation
                {
                    RoomID = 10,
                    RoomNumber = "110",
                    RoomDescription = "Deluxe suite with two bedrooms.",
                    RoomMaxCapacity = 6,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 350.00m,
                    RoomTypeID = 3
                },
                new RoomInformation
                {
                    RoomID = 11,
                    RoomNumber = "111",
                    RoomDescription = "Single room with shared bathroom.",
                    RoomMaxCapacity = 1,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 70.00m,
                    RoomTypeID = 1
                },
                new RoomInformation
                {
                    RoomID = 12,
                    RoomNumber = "112",
                    RoomDescription = "Double room with king-sized bed.",
                    RoomMaxCapacity = 2,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 160.00m,
                    RoomTypeID = 2
                },
                new RoomInformation
                {
                    RoomID = 13,
                    RoomNumber = "113",
                    RoomDescription = "Suite with jacuzzi.",
                    RoomMaxCapacity = 3,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 220.00m,
                    RoomTypeID = 3
                } }                
            );}

        public List<RoomInformation> GetRoomInformations()
        {
           

            return list;
        }
        public void SaveRoomInformation(RoomInformation r)
        {
            list.Add( r );
        }

        public void UpdateRoomInformation (RoomInformation r)
        {
            foreach ( var current in list.ToList() )
            {
                if (current.RoomID == r.RoomID )
                {
                    current.RoomDescription = r.RoomDescription;
                    current.RoomPricePerDate    = r.RoomPricePerDate;
                    current.RoomTypeID = r.RoomTypeID;
                    current.RoomNumber = r.RoomNumber;
                    current.RoomDescription = r.RoomDescription;
                    current.RoomMaxCapacity = r.RoomMaxCapacity;
                    current.RoomStatus = r.RoomStatus;
                }
            }
        }

        public void DeleteRoomInformation(RoomInformation r)
        {
            foreach (var current in list.ToList())
            {
                if (current.RoomID == r.RoomID)
                {
                    list.Remove(current);
                }
            }
        }

        public RoomInformation GetRoomInformationById (int id)
        {
            foreach (var current in list.ToList())
            {
                if (current.RoomID == id)
                {
                    return current;
                }
            }
            return null;
        }
    }
}
