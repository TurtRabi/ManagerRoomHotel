using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomInfomationRepository
    {
        public List<RoomInformation> listRoomInfomation();
        public RoomInformation GetRoomInformation(int id);
        //public bool AddRoomInformation(RoomInformation roomInformation);
        public bool DeleteRoomInformation(int id);
        public bool EnableRoomInformation(int id);
        public bool UpdateInformation(RoomInformation roomInformation);
        public bool AddRoomInformation(RoomInformation roomInformation);

    }
}
