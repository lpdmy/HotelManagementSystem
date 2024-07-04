using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomInformationRepository
    {
        List<RoomInformation> GetRoomInformations();
        void SaveRoomInformation(RoomInformation r);
        void DeleteRoomInformation(RoomInformation r);
        void UpdateRoomInformation(RoomInformation r);
        RoomInformation GetRoomInformationById(int roomId);

        int GetNewId();
    }
}
