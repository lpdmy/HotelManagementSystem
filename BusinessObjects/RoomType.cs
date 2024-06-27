namespace BusinessObjects
{

    public class RoomType
    {
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public string TypeDescription { get; set; }
        public string TypenNote { get; set; }

        public override string ToString()
        {
            return RoomTypeName;
        }
    }


}
