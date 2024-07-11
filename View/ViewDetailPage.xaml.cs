using BusinessObject.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for ViewDetailPage.xaml
    /// </summary>
    public partial class ViewDetailPage : Page
    {
        private IBookingReservationService bookingReservationService;
        private IBookingDetailService bookingDetailService;
        private IRoomInfomationService roomInfomationService;
        public ViewDetailPage()
        {
            InitializeComponent();
            bookingReservationService = new BookingReservationService();
            bookingDetailService = new BookingDetailService();
            roomInfomationService= new RoomInformationService();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("BookingHistoryPage.xaml", UriKind.Relative));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
             
            var customer = Application.Current.Properties["Customer"] as Customer;
            var bookingResevationId = Application.Current.Properties["selectBookingResevationId"].ToString();
            
            txt_fullName.Content = customer.CustomerFullName;
            txt_phone.Content = customer.Telephone;
            var bookingResevation = bookingReservationService.getBookingReservation(Int32.Parse(bookingResevationId));
            var bookingDetail = bookingDetailService.GetBookingDetail(bookingResevation.BookingReservationId);
            txt_totalPrice.Content= bookingResevation.TotalPrice.ToString();
            txt_startday.Content=bookingDetail.StartDate.ToString();
            txt_Endday.Content=bookingDetail.EndDate.ToString();
            var roomInfomation = roomInfomationService.GetRoomInformation(bookingDetail.RoomId);
            toom_Id.Content = roomInfomation.RoomId;
            txt_priceperday.Content = roomInfomation.RoomPricePerDay.ToString();
            txt_roomDetail.Content = roomInfomation.RoomDetailDescription.ToString();

        }
    }
}
