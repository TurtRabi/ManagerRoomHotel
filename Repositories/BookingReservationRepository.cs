using BusinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingReservationRepository : IBookingRevervationRepository
    {
        public bool addBookingReservation(BookingReservation reservation)=>BookingReservationDAO.AddBookingReservation(reservation);    

        public bool disableBookingReservation(int id)=>BookingReservationDAO.DeleteBookingReservation(id);

        public BookingReservation getBookingReservation(int id)=> BookingReservationDAO.GetBookingReservation(id);
        

        public List<BookingReservation> getListBookingReservation()=>BookingReservationDAO.getListBookingReservation();

        public List<BookingReservation> getListBookingResevation(int customerId)=>BookingReservationDAO.getListBookingByIdCustomer(customerId); 
        

        public bool updateBookingReservation(BookingReservation bookingReservation)=>BookingReservationDAO.UpdateBookingReservation(bookingReservation);
        
    }
}
