using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingDetailRepository
    {
        public List<BookingDetail> listBookingDetails();
        public BookingDetail GetBookingDetail(int idRoom);
        public bool AddBookingDetail(BookingDetail bookingDetail);
        public bool UpdateBookingDetail(BookingDetail bookingDetail);
    }
}
