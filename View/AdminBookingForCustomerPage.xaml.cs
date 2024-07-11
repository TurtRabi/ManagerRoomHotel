using BusinessObject.Models;
using DataAccessLayer;
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
    /// Interaction logic for AdminBookingForCustomerPage.xaml
    /// </summary>
    public partial class AdminBookingForCustomerPage : Page
    {
        private IRoomInfomationService roomInfomationService;
        private IBookingDetailService bookingDetailService;
        private IBookingReservationService bookingReservationService;
        private ICustomerService customerService;
        public AdminBookingForCustomerPage()
        {
            InitializeComponent();
            roomInfomationService = new RoomInformationService();
            bookingDetailService = new BookingDetailService();
            customerService = new CustomerService();
            bookingReservationService = new BookingReservationService();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string idRoom = Application.Current.Properties["SelectedRoomId"].ToString();
            RoomInformation roomInformation = roomInfomationService.GetRoomInformation(Int32.Parse(idRoom));
            roomNumber.Content = roomInformation.RoomNumber;
            txt_priceperday.Content = roomInformation.RoomPricePerDay.ToString();
            txt_roomDetail.Content = roomInformation.RoomDetailDescription;
            txt_roomId.Content = roomInformation.RoomId;

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AdminManagerBookingResevationPage.xaml", UriKind.Relative));
        }

        private void btn_Accept_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want Booking", "Comfim", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DateOnly bookingDay = DateOnly.FromDateTime(DateTime.Now);
                Decimal.TryParse(txt_totalPrice.Content.ToString(), out Decimal totalPrice);
                string customerName = txt_fullName.Text;
                string customerPhone = txt_phone.Text;
                string email = txt_Email.Text;
                string room_id = txt_roomId.Content.ToString();

                Customer customer = new Customer();
                customer.CustomerFullName = customerName;
                customer.Telephone = customerPhone;
                customer.Password = null;
                customer.CustomerBirthday = null;
                customer.CustomerStatus = 0;
                customer.EmailAddress = email;


                if (customerService.addCustomer(customer))
                {
                    Customer customer1 = customerService.getCustomerByNameAndPhone(customerName, customerPhone);
                 
                    BookingReservation bookingReservation = new BookingReservation();   
                    bookingReservation.TotalPrice = totalPrice;
                    bookingReservation.CustomerId = customer.CustomerId;
                    bookingReservation.BookingStatus = 1;
                    bookingReservation.BookingDate=DateOnly.FromDateTime(DateTime.Now);
                    if (bookingReservationService.addBookingReservation(bookingReservation))
                    {
                        DateOnly startDay = DateOnly.FromDateTime(txt_startday.SelectedDate.Value);

                        DateTime.TryParse(txt_Endday.Content.ToString(), out DateTime dateTime);
                        DateOnly endDay = DateOnly.FromDateTime(dateTime);
                        RoomInformation roomInformation = roomInfomationService.GetRoomInformation(Int32.Parse(room_id));
                        BookingDetail bookingDetail = new BookingDetail();
                        bookingDetail.ActualPrice = roomInformation.RoomPricePerDay;
                        bookingDetail.RoomId = roomInformation.RoomId;
                        bookingDetail.StartDate = startDay;
                        bookingDetail.EndDate = endDay;
                        bookingDetail.BookingReservationId=bookingReservation.BookingReservationId;
                        
                        if (bookingDetailService.AddBookingDetail(bookingDetail)) {
                            NavigationService.Navigate(new Uri("AdminManagerBookingResevationPage.xaml", UriKind.Relative));
                        }
                        else
                        {
                            MessageBox.Show("false");
                        }
                        
                    }
                }
            }
                    
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txt_BookingHour.SelectedItem is ComboBoxItem selectedItem)
            {


                string selectedValue = selectedItem.Content.ToString();

                string pricePerDay = txt_priceperday.Content.ToString();

                if (int.TryParse(selectedValue, out int hours) && Decimal.TryParse(pricePerDay, out Decimal price))
                {
                    decimal totalPrice = hours * price;
                    txt_totalPrice.Content = totalPrice.ToString();

                    DateTime txtStartDay;
                    if (txt_startday.SelectedDate.HasValue)
                    {
                        txtStartDay = txt_startday.SelectedDate.Value;
                    }
                    else
                    {
                        txtStartDay = DateTime.Now.Date;
                        txt_startday.SelectedDate = txtStartDay;
                    }
                    DateTime txtEndDay = txtStartDay + TimeSpan.FromDays(hours);
                    txt_Endday.Content = DateOnly.FromDateTime(txtEndDay).ToString();
                }
                else
                {
                    txt_totalPrice.Content = "Invalid input";
                }
            }
        }

        private void txt_fullName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_phone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_startday_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txt_startday.SelectedDate.HasValue)
            {
                DateTime selectedDate = txt_startday.SelectedDate.Value;
                DateTime currentDate = DateTime.Now.Date;

                if (selectedDate < currentDate)
                {
                    txt_startday.SelectedDate = currentDate;
                }
                else
                {
                }
            }
            else
            {

            }

        }
    }
}
