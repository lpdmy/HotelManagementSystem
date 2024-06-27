using BusinessObjects;

namespace DataAccessLayer
{
    public class RoomTypeDAO : SingletonBase<RoomTypeDAO>
    {
        public List<RoomType> GetRoomTypes()
        {
            var list = new List<RoomType>()
            {
            new RoomType
            {
                RoomTypeID = 1,
                RoomTypeName = "Standard Room",
                TypeDescription = "Basic room with essential amenities.",
                TypenNote = "No special notes."
            },
            new RoomType
            {
                RoomTypeID = 2,
                RoomTypeName = "Deluxe Room",
                TypeDescription = "Luxurious room with additional amenities.",
                TypenNote = "Includes a mini-bar and city view."
            },
            new RoomType
            {
                RoomTypeID = 3,
                RoomTypeName = "Suite",
                TypeDescription = "Large and luxurious suite.",
                TypenNote = "Includes a separate living area and jacuzzi."
            },
             new RoomType
            {
                RoomTypeID = 4,
                RoomTypeName = "Family Room",
                TypeDescription = "Spacious room suitable for families.",
                TypenNote = "Equipped with bunk beds and children's play area."
            },
            new RoomType
            {
                RoomTypeID = 5,
                RoomTypeName = "Ocean View Room",
                TypeDescription = "Room with a view of the ocean.",
                TypenNote = "Perfect for guests looking for a scenic view."
            }
            };
            return list;
        }

        public RoomType GetRoomTypeById(int id)
        {
            foreach (var roomType in GetRoomTypes())
            {
                if (roomType.RoomTypeID == id) return roomType;
            }
            return null!;
        }
    }
}
