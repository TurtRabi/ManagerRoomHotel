using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomInformationDAO
    {
        public static List<RoomInformation> listRoomInfomation()
        {
            using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            return context.RoomInformations.ToList();
        }

        public static RoomInformation GetRoomInformation(int id)
        {
            FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            return context.RoomInformations.SingleOrDefault(c => c.RoomId.Equals(id));
        }

        public static bool AddRoomInformation(RoomInformation roomInformation)
        {
            try
            {
                using (FuminiHotelManagementContext context = new FuminiHotelManagementContext())
                {
                    context.RoomInformations.Add(roomInformation);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (DbUpdateException ex)
            {
                // Log lỗi hoặc xử lý ngoại lệ cụ thể cho DbUpdateException
                Console.WriteLine($"DbUpdateException occurred: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc xử lý ngoại lệ chung
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return false;
            }
        }

        public static bool DeleteRoomInformation(int id)
        {
            FuminiHotelManagementContext context= new FuminiHotelManagementContext();
            RoomInformation  roomInformation = context.RoomInformations.SingleOrDefault(c=> c.RoomId.Equals(id));
            
            if (roomInformation != null)
            {
                RoomInformation roomInformation1 = roomInformation;
                roomInformation1.RoomStatus = 0;
                context.Entry(roomInformation).CurrentValues.SetValues(roomInformation1);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool enableRoomInformation(int id)
        {
            FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            RoomInformation roomInformation = context.RoomInformations.SingleOrDefault(c => c.RoomId.Equals(id));

            if (roomInformation != null)
            {
                RoomInformation roomInformation1 = roomInformation;
                roomInformation1.RoomStatus = 1;
                context.Entry(roomInformation).CurrentValues.SetValues(roomInformation1);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateInformation(RoomInformation roomInformation)
        {
            FuminiHotelManagementContext context = new FuminiHotelManagementContext();

           RoomInformation findRoom = context.RoomInformations.SingleOrDefault(c=>c.RoomId.Equals(roomInformation.RoomId));
            if (findRoom != null)
            {
                context.Entry(findRoom).CurrentValues.SetValues(roomInformation);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

     

    }
}
