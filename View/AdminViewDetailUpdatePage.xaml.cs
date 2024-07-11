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
    /// Interaction logic for AdminViewDetailUpdatePage.xaml
    /// </summary>
    public partial class AdminViewDetailUpdatePage : Page
    {
        private IBookingReservationService bookingReservation;
        private ICustomerService customerService;
        private IRoomInfomationService roomInfomationService;
        private IBookingDetailService bookingDetailService;
        public AdminViewDetailUpdatePage()
        {
            InitializeComponent();
            bookingReservation= new BookingReservationService();
            customerService= new CustomerService();
            roomInfomationService = new RoomInformationService();
            bookingDetailService= new BookingDetailService();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AdminManagerBookingResevationPage.xaml", UriKind.Relative));
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want Update", "Comfim", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                string? id_bookingResevation = txt_bookingResrvation.Content.ToString();
                string getFullName = txt_fullName.Text;
                string getTelephone = txt_phone.Text;
                int room_id = 0;


                var getBookingResevation = bookingReservation.getBookingReservation(Int32.Parse(id_bookingResevation));

                getBookingResevation.BookingStatus = 1;

                if (bookingReservation.updateBookingReservation(getBookingResevation))
                {
                    MessageBox.Show("Booking success");
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            var selection = Application.Current.Properties["AdminChooseBooking"].ToString();
            if (selection != null) {
                var getBookingResevation = bookingReservation.getBookingReservation(Int32.Parse(selection));
                var getBookingDetail = bookingDetailService.GetBookingDetail(getBookingResevation.BookingReservationId);
                var getCustomer = customerService.getCustomerById(getBookingResevation.CustomerId);
                var roomInfomation = roomInfomationService.GetRoomInformation(getBookingDetail.RoomId);
                txt_fullName.Text = getCustomer.CustomerFullName;
                txt_phone.Text = getCustomer.Telephone;
                txt_fakeRoomNumber.Content = roomInfomation.RoomNumber.ToString();
                txt_priceperday.Content = roomInfomation.RoomPricePerDay.ToString();
                txt_startday.Content=getBookingDetail.StartDate.ToString();
                txt_Endday.Content=getBookingDetail.EndDate.ToString();
                txt_roomDetail.Content = roomInfomation.RoomDetailDescription;
                txt_totalPrice.Content = getBookingResevation.TotalPrice.ToString();
                txt_bookingResrvation.Content=getBookingResevation.BookingReservationId.ToString();
                txt_fakeRoomNumberId.Content= roomInfomation.RoomId.ToString();
            }
        }

        private void txt_roomNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
