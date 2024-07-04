using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomInfomationRepository : IRoomInformationRepository
    {
        public void DeleteRoomInformation(RoomInformation r)
        {
            RoomInformationDAO.Instance.DeleteRoomInformation(r);
        }

        public int GetNewId()
        {
            return RoomInformationDAO.Instance.GetNewId();
        }

        public RoomInformation GetRoomInformationById(int roomId)
        {
            return RoomInformationDAO.Instance.GetRoomInformationById(roomId);
        }

        public List<RoomInformation> GetRoomInformations()
        {
            return RoomInformationDAO.Instance.GetRoomInformations();
        }

        public void SaveRoomInformation(RoomInformation r)
        {
            RoomInformationDAO.Instance.SaveRoomInformation(r);
        }

        public void UpdateRoomInformation(RoomInformation r)
        {
            RoomInformationDAO.Instance.UpdateRoomInformation(r);
        }
    }
}
