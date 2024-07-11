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
    /// Interaction logic for AdminManagerBookingResevationPage.xaml
    /// </summary>
    public partial class AdminManagerBookingResevationPage : Page
    {
        private IBookingReservationService bookingReservationService;
        private ICustomerService customerService;
        public AdminManagerBookingResevationPage()
        {
            InitializeComponent();
            bookingReservationService = new BookingReservationService();
            customerService = new CustomerService();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var listBookingResevation = bookingReservationService.getListBookingReservation();
            foreach(var item in listBookingResevation)
            {
                var customer = customerService.getCustomerById(item.CustomerId);
                item.Customer=customer;
            }

            ListBookingResevation.ItemsSource = listBookingResevation;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var booking = button.DataContext as BookingReservation;
            Application.Current.Properties["AdminChooseBooking"] = booking.BookingReservationId;
           
            NavigationService.Navigate(new Uri("AdminViewDetailUpdatePage.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Do you want disable", "Comfim", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Button button = sender as Button;
                var booking = button.DataContext as BookingReservation;
                bookingReservationService.disableBookingReservation(booking.BookingReservationId);
                Page_Loaded(sender, e);


            }
        }

        private void ListRoomtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txt_SearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_SearchName.Text) && txt_SearchName.Text.Length > 0)
            {
                text_maxPrice.Visibility = Visibility.Collapsed;
            }
            else
            {
                text_maxPrice.Visibility = Visibility.Visible;
            }
        }

        private void text_maxPrice_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txt_SearchName.Focus();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            string txtPhone = txt_phone.Text;
            string txtName = txt_SearchName.Text;
            List<BookingReservation> findlist = bookingReservationService.getListBookingReservation();
            foreach (var item in findlist)
            {
                var customer = customerService.getCustomerById(item.CustomerId);
                item.Customer = customer;
            }
            if (txtPhone.Trim() != "" && txtName.Trim() != "")
            {
                findlist = findlist.Where(c => c.Customer.Telephone.Equals(txtPhone.Trim()) && c.Customer.CustomerFullName.Equals(txtName)).ToList();
            }
            else if (txtPhone.Trim() != "" && txtName.Trim() == "")
            {
                findlist = findlist.Where(c => c.Customer.Telephone.Contains(txtPhone.Trim())).ToList();
            }
            else if(txtPhone.Trim() == "" && txtName.Trim() != "")
            {
                findlist = findlist.Where(c=>c.Customer.CustomerFullName.Contains(txtName)).ToList();
            }
            else
            {
                findlist= bookingReservationService.getListBookingReservation();
                foreach (var item in findlist)
                {
                    var customer = customerService.getCustomerById(item.CustomerId);
                    item.Customer = customer;
                }
            }
            ListBookingResevation.ItemsSource = findlist;
        }

        private void text_phone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txt_phone.Focus();
        }

        private void txt_phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_phone.Text) && txt_phone.Text.Length > 0)
            {
                text_phone.Visibility = Visibility.Collapsed;
            }
            else
            {
                text_phone.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
          
            NavigationService.Navigate(new Uri("HomeCustomerPage.xaml", UriKind.Relative));
            
        }
    }
}
