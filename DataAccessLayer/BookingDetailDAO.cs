using BusinessObject.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class BookingDetailDAO
    {
        public static List<BookingDetail> ListBookingDetail()
        {
            using (FuminiHotelManagementContext context = new FuminiHotelManagementContext())
            {
                return context.BookingDetails.ToList();
            }
        }

        public static BookingDetail GetBookingDetail(int roomId)
        {
            using (FuminiHotelManagementContext context = new FuminiHotelManagementContext())
            {
                return context.BookingDetails.FirstOrDefault(c => c.BookingReservationId.Equals(roomId));
            }
        }

        public static bool AddBookingDetail(BookingDetail bookingDetail)
        {
            try
            {
                using (FuminiHotelManagementContext context = new FuminiHotelManagementContext())
                {
                    
                    context.BookingDetails.Add(bookingDetail);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return false;
            }
        }

        public bool AddBookingDetail1(BookingDetail bookingDetail)
        {
            try
            {
                using (FuminiHotelManagementContext context = new FuminiHotelManagementContext())
                {
                    bookingDetail.BookingReservationId = 4;
                    bookingDetail.StartDate = DateOnly.FromDateTime(DateTime.Now);
                    bookingDetail.EndDate = DateOnly.FromDateTime(DateTime.Now);
                    bookingDetail.RoomId = 1;
                    bookingDetail.ActualPrice = 1234;

                    context.BookingDetails.Add(bookingDetail);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return false;
            }
        }

        public static bool UpdateBookingDetail(BookingDetail bookingDetail)
        {
            try
            {
                using (FuminiHotelManagementContext context = new FuminiHotelManagementContext())
                {
                    var findBookingDetail = context.BookingDetails.Single(c => c.BookingReservationId.Equals(bookingDetail.BookingReservationId));
                    context.Entry(findBookingDetail).CurrentValues.SetValues(bookingDetail);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency exception
                Console.WriteLine("Concurrency exception: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return false;
            }
        }
    }
}
