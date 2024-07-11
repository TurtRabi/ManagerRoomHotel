using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookingReservationService
    {
        public List<BookingReservation> getListBookingReservation();
        public BookingReservation getBookingReservation(int id);
        public bool disableBookingReservation(int id);
        public bool addBookingReservation(BookingReservation reservation);
        public bool updateBookingReservation(BookingReservation bookingReservation);
        public List<BookingReservation> getListBookingResevation(int customerId);
    }
}
