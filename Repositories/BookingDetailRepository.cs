using BusinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public bool AddBookingDetail(BookingDetail bookingDetail)=>BookingDetailDAO.AddBookingDetail(bookingDetail);

        public BookingDetail GetBookingDetail(int idRoom) => BookingDetailDAO.GetBookingDetail(idRoom);
        
        public List<BookingDetail> listBookingDetails()=>BookingDetailDAO.ListBookingDetail();
        public bool UpdateBookingDetail(BookingDetail bookingDetail) =>BookingDetailDAO.UpdateBookingDetail(bookingDetail); 
    }
}
