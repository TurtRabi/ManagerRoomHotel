using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomTypeDAO
    {
        public static List<RoomType> listRoomType()
        {
            FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            RoomType roomType = new RoomType();
            return context.RoomTypes.ToList();
        }

        public static RoomType getRoomType(int id)
        {
            FuminiHotelManagementContext context= new FuminiHotelManagementContext();
            return context.RoomTypes.SingleOrDefault(c => c.RoomTypeId.Equals(id));
        }

        public static bool addRoomType(RoomType roomType)
        {
            try
            {
                FuminiHotelManagementContext context = new FuminiHotelManagementContext();
                context.RoomTypes.Add(roomType);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool removeRoomType(int id)
        {
            try
            {
                FuminiHotelManagementContext context = new FuminiHotelManagementContext();
                RoomType roomType = new RoomType();
                context.RoomTypes.Remove(roomType);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex) { 
                return false;
            }
        }

        public static bool updateRoomType(RoomType roomType)
        {
            try
            {
                FuminiHotelManagementContext context = new FuminiHotelManagementContext();
                RoomType findRoomtype = context.RoomTypes.SingleOrDefault(c=>c.RoomTypeId.Equals(roomType.RoomTypeId));
                if (findRoomtype!=null)
                {
                    context.RoomTypes.Entry(findRoomtype).CurrentValues.SetValues(roomType);
                    context.SaveChanges() ;
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static RoomType getRoomTypeByName(string name)
        {
            FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            return context.RoomTypes.SingleOrDefault(c => c.RoomTypeName.Equals(name));
        }
    }
}
