using BusinessObject.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingDetailService : IBookingDetailService
    {
        private IBookingDetailRepository DetailRepository;
        public BookingDetailService()
        {
            DetailRepository = new BookingDetailRepository();
        }
        public bool AddBookingDetail(BookingDetail bookingDetail)
            =>DetailRepository.AddBookingDetail(bookingDetail);

        public BookingDetail GetBookingDetail(int idRoom)
            =>DetailRepository.GetBookingDetail(idRoom);

        public List<BookingDetail> listBookingDetails()
            =>DetailRepository.listBookingDetails();

        public bool UpdateBookingDetail(BookingDetail bookingDetail)
            =>DetailRepository.UpdateBookingDetail(bookingDetail);
    }
}
