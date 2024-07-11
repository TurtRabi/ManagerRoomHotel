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
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        private IBookingReservationService bookingReservationService;
        private ICustomerService customerService;
        public ReportPage()
        {
            InitializeComponent();
            bookingReservationService = new BookingReservationService();
            customerService = new CustomerService();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            DateOnly startDay = DateOnly.FromDateTime(DateTime.Parse(txt_startDay.Text));
            DateOnly endDAy = DateOnly.FromDateTime(DateTime.Parse(txt_endDay.Text));

            var findList = bookingReservationService.getListBookingReservation();
            foreach (var item in findList)
            {
                var customer = customerService.getCustomerById(item.CustomerId);
                item.Customer = customer;
            }

            if (startDay < endDAy)
            {
                findList = findList.Where(c=>c.BookingDate>= startDay&& c.BookingDate<= endDAy).OrderByDescending(c=>c.BookingDate).ToList();
            }
            else
            {
                MessageBox.Show("Invalid Formay Day");
            }
            ListBookingResevation.ItemsSource = findList;
        }

        private void ListRoomtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var listBookingResevation = bookingReservationService.getListBookingReservation();
            foreach (var item in listBookingResevation)
            {
                var customer = customerService.getCustomerById(item.CustomerId);
                item.Customer = customer;
            }

            ListBookingResevation.ItemsSource = listBookingResevation;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var view = button.DataContext as BookingReservation;
            Application.Current.Properties["AdminChooseBooking"] = view.BookingReservationId;
            NavigationService.Navigate(new Uri("AdminViewSort.xaml", UriKind.Relative));
        }
    }
}
