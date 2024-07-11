using BusinessObject.Models;
using Repositories;
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
    /// Interaction logic for BookingHistoryPage.xaml
    /// </summary>
    public partial class BookingHistoryPage : Page
    {
        private IBookingReservationService bookingReservationService;
        private IBookingDetailRepository bookingDetailRepository;
        public BookingHistoryPage()
        {
            InitializeComponent();
            bookingReservationService = new BookingReservationService();
            bookingDetailRepository = new BookingDetailRepository();
            
        }

        private void ListRoomtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var booking = button.DataContext as BookingReservation;
            Application.Current.Properties["selectBookingResevationId"] = booking.BookingReservationId;

            NavigationService.Navigate(new Uri("ViewDetailPage.xaml", UriKind.Relative));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var customer = Application.Current.Properties["Customer"] as Customer;
            var listBookingResevationList=bookingReservationService.getListBookingResevation(customer.CustomerId);
            foreach (BookingReservation bookingReservation in listBookingResevationList) {
                bookingReservation.Customer=customer;
            }
            ListHistoryBooking.ItemsSource = listBookingResevationList;
        }
    }
}
