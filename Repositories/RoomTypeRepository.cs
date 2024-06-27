using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        public RoomType GetRoomTypeById(int id)
        {
            return RoomTypeDAO.Instance.GetRoomTypeById(id);
        }

        public List<RoomType> GetRoomTypes()
        {
            return RoomTypeDAO.Instance.GetRoomTypes();
        }
    }
}
