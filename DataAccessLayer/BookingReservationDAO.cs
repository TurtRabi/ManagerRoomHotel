
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingReservationDAO
    {
        public static List<BookingReservation> getListBookingReservation()
        {
            using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            return context.BookingReservations.ToList();
        }

        public static BookingReservation GetBookingReservation(int id)
        {
            using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
            return context.BookingReservations.SingleOrDefault(c => c.BookingReservationId.Equals(id));
        }
        public static bool AddBookingReservation(BookingReservation reservation)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var listmax = context.BookingReservations.ToList().OrderByDescending(c => c.BookingReservationId).FirstOrDefault();
                if (listmax != null) { 
                    reservation.BookingReservationId= listmax.BookingReservationId+1;
                }
                else
                {
                    reservation.BookingReservationId = 1;
                }
                
                context.BookingReservations.Add(reservation);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteBookingReservation(int id)
        {
            try
            {
                using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
                var findDisableBooking = context.BookingReservations.SingleOrDefault(c=>c.BookingReservationId.Equals(id));
                findDisableBooking.BookingStatus = 0;
                context.Entry(findDisableBooking).CurrentValues.SetValues(findDisableBooking);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex) { 
                return false;
            }
        }

        public static bool UpdateBookingReservation(BookingReservation reservation)
        {
            try
            {
                using FuminiHotelManagementContext context = new FuminiHotelManagementContext();
                var findDisableBooking = context.BookingReservations.SingleOrDefault(c => c.BookingReservationId.Equals(reservation.BookingReservationId));
                context.Entry(findDisableBooking).CurrentValues.SetValues(reservation);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<BookingReservation> getListBookingByIdCustomer(int customerId)
        {
             using var context = new FuminiHotelManagementContext();
             return context.BookingReservations.Where(c=>c.CustomerId == customerId).ToList();
        }

    }
}
