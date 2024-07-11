using BusinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        public bool addRoomType(RoomType roomType) => RoomTypeDAO.addRoomType(roomType);
        

        public RoomType getRoomType(int id) => RoomTypeDAO.getRoomType(id);

        public RoomType getRoomTypeByName(string name)=> RoomTypeDAO.getRoomTypeByName(name);

        public List<RoomType> listRoomType() => RoomTypeDAO.listRoomType();
        

        public bool removeRoomType(int id)=>RoomTypeDAO.removeRoomType(id);
        

        public bool updateRoomType(RoomType roomType)=> RoomTypeDAO.updateRoomType(roomType);
    }
}
