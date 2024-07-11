using BusinessObject.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomInformationService : IRoomInfomationService
    {
        private readonly IRoomInfomationRepository roomInfomationRepository;
        public RoomInformationService()
        {
            roomInfomationRepository = new RoomInfomationRepository();
        }

        public bool AddInfomationService(RoomInformation roomInformation)
            =>roomInfomationRepository.AddRoomInformation(roomInformation);
        //public bool AddRoomInformation(RoomInformation roomInformation)
        //=>roomInfomationRepository.AddRoomInformation(roomInformation);


        public bool DeleteRoomInformation(int id)
            =>roomInfomationRepository.DeleteRoomInformation(id);

        public bool EnableeRoomInformation(int id)
            =>roomInfomationRepository.EnableRoomInformation(id);

        public RoomInformation GetRoomInformation(int id)
            =>roomInfomationRepository.GetRoomInformation(id);

        public List<RoomInformation> listRoomInfomation()
            =>roomInfomationRepository.listRoomInfomation();

        public bool UpdateInformation(RoomInformation roomInformation)
            =>roomInfomationRepository.UpdateInformation(roomInformation);
    }
}
