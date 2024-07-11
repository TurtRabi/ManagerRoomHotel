using BusinessObject.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository roomTypeRepository;
        public RoomTypeService()
        {
            roomTypeRepository = new RoomTypeRepository();
        }
        public bool addRoomType(RoomType roomType)=>roomTypeRepository.addRoomType(roomType);

        public RoomType getRoomType(int id)=>roomTypeRepository.getRoomType(id);

        public RoomType getRoomTypeByName(string name)=>roomTypeRepository.getRoomTypeByName(name);

        public List<RoomType> listRoomType()=>roomTypeRepository.listRoomType();
        

        public bool removeRoomType(int id)=>roomTypeRepository.removeRoomType(id);
        

        public bool updateRoomType(RoomType roomType)=>roomTypeRepository.updateRoomType(roomType);
        
    }
}
