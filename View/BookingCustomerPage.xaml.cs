using BusinessObject.Models;
using DataAccessLayer;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Interaction logic for BookingCustomerPage.xaml
    /// </summary>
    public partial class BookingCustomerPage : Page
    {
        private IRoomInfomationService roomInfomationService;
        private IBookingReservationService bookingReservationService;
        private IBookingDetailService bookingDetailService;
        public BookingCustomerPage()
        {
            InitializeComponent();
            roomInfomationService = new RoomInformationService();
            bookingReservationService= new BookingReservationService();
            bookingDetailService = new BookingDetailService();
        }

        private void btn_Accept_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want Booking", "Comfim", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) {
                RoomInformation roomInformation = roomInfomationService.GetRoomInformation(Int32.Parse(toom_Id.Content.ToString()));
                if (roomInformation != null && roomInformation.RoomStatus==1) {
                    roomInformation.RoomStatus = 0;
                    roomInfomationService.UpdateInformation(roomInformation);
                    DateOnly bookingDay = DateOnly.FromDateTime(DateTime.Now);
                    Decimal.TryParse(txt_totalPrice.Content.ToString(), out Decimal totalPrice);
                    var customer = Application.Current.Properties["Customer"] as Customer;
                    int CustomerId = customer.CustomerId;
                    byte bookingStatus = 1;



                    BookingReservation bookingReservation = new BookingReservation();
                    bookingReservation.BookingStatus = bookingStatus;
                    bookingReservation.BookingDate = bookingDay;
                    bookingReservation.TotalPrice = totalPrice;
                    bookingReservation.CustomerId = CustomerId;


                    DateOnly startDay = DateOnly.FromDateTime(txt_startday.SelectedDate.Value);

                    DateTime.TryParse(txt_Endday.Content.ToString(), out DateTime dateTime);
                    DateOnly endDay = DateOnly.FromDateTime(dateTime);

                    Decimal.TryParse(txt_priceperday.Content.ToString(), out decimal actualPrice);





                    if (bookingReservationService.addBookingReservation(bookingReservation))
                    {
                        BookingDetail bookingDetail = new BookingDetail();

                        BookingReservation listMax = bookingReservationService.getListBookingReservation().OrderByDescending(c => c.BookingReservationId).FirstOrDefault();

                        bookingDetail.StartDate = startDay;
                        bookingDetail.EndDate = endDay;
                        bookingDetail.RoomId = roomInformation.RoomId;
                        bookingDetail.ActualPrice = roomInformation.RoomPricePerDay;
                        bookingDetail.BookingReservationId = listMax.BookingReservationId;

                        if (bookingDetailService.AddBookingDetail(bookingDetail))
                        {
                            MessageBox.Show("add success");
                            NavigationService.Navigate(new Uri("HomeCustomerPage.xaml", UriKind.Relative));
                        }
                        else
                        {
                            MessageBox.Show("add false");
                        }

                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Room is Booking");
                }
            }
                
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("HomeCustomerPage.xaml", UriKind.Relative));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var customer = Application.Current.Properties["Customer"] as Customer;
            txt_fullName.Content = customer.CustomerFullName;
            txt_phone.Content = customer.Telephone;
            if (Application.Current.Properties["SelectedRoomId"] is int selectedRoomId)
            {
                toom_Id.Content = selectedRoomId;
                var roomInfomation = roomInfomationService.GetRoomInformation(selectedRoomId);
                txt_priceperday.Content = roomInfomation.RoomPricePerDay.ToString();
                txt_roomDetail.Content = roomInfomation.RoomDetailDescription;
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
                    DateTime txtEndDay = txtStartDay + TimeSpan.FromHours(hours);
                    txt_Endday.Content=DateOnly.FromDateTime(txtEndDay).ToString();
                }
                else
                {
                    txt_totalPrice.Content = "Invalid input";
                }
            }
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
