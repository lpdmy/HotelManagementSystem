namespace BusinessObjects
{
    public class RoomInformation
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string RoomDescription { get; set; }
        public int RoomMaxCapacity { get; set; }
        public RoomStatus RoomStatus { get; set; } = RoomStatus.Active;
        public decimal RoomPricePerDate { get; set; }
        public int RoomTypeID { get; set; } // Foreign key to RoomType

        // Navigation property to RoomType
        public RoomType RoomType { get; set; }
    }
}
