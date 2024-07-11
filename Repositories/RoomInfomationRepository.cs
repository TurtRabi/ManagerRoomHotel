using BusinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomInfomationRepository : IRoomInfomationRepository
    {
        public bool AddRoomInformation(RoomInformation roomInformation)
            =>RoomInformationDAO.AddRoomInformation(roomInformation);

        //public bool AddRoomInformation(RoomInformation roomInformation)=>RoomInformationDAO.AddRoomInformation(roomInformation);


        public bool DeleteRoomInformation(int id)=>RoomInformationDAO.DeleteRoomInformation(id);

        public bool EnableRoomInformation(int id)=>RoomInformationDAO.enableRoomInformation(id);

        public RoomInformation GetRoomInformation(int id)=>RoomInformationDAO.GetRoomInformation(id);
        

        public List<RoomInformation> listRoomInfomation()=>RoomInformationDAO.listRoomInfomation();
        

        public bool UpdateInformation(RoomInformation roomInformation)=>RoomInformationDAO.UpdateInformation(roomInformation);
        
    }
}
