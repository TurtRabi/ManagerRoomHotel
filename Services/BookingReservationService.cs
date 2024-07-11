using BusinessObject.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingReservationService : IBookingReservationService
    {
        private readonly IBookingRevervationRepository bookingRevervationRepository;

        public BookingReservationService()
        {
            bookingRevervationRepository = new BookingReservationRepository();
        }
        public bool addBookingReservation(BookingReservation reservation)
            => bookingRevervationRepository.addBookingReservation(reservation);

        public bool disableBookingReservation(int id) 
            => bookingRevervationRepository.disableBookingReservation(id);

        public BookingReservation getBookingReservation(int id)
            => bookingRevervationRepository.getBookingReservation(id);

        public List<BookingReservation> getListBookingReservation()
            => bookingRevervationRepository.getListBookingReservation();

        public List<BookingReservation> getListBookingResevation(int customerId)
            =>bookingRevervationRepository.getListBookingResevation(customerId);

        public bool updateBookingReservation(BookingReservation bookingReservation)
            => bookingRevervationRepository.updateBookingReservation(bookingReservation);
    }
}
