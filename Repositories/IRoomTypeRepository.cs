using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public  interface IRoomTypeRepository
    {
        public List<RoomType> listRoomType();
        public RoomType getRoomType(int id);
        public RoomType getRoomTypeByName(String name);
        public bool addRoomType(RoomType roomType);
        public bool removeRoomType(int id);
        public bool updateRoomType(RoomType roomType);
    }
}
