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
    /// Interaction logic for ViewPage.xaml
    /// </summary>
    public partial class ViewPage : Page
    {
        private IRoomInfomationService roomInfomationService;
        private IRoomTypeService roomTypeService;
        public ViewPage()
        {
            InitializeComponent();
            roomInfomationService = new RoomInformationService();
            roomTypeService = new RoomTypeService();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(Application.Current.Properties["SelectedRoomId"] is int selectedRoomId)
            {
                var roomInfomation=roomInfomationService.GetRoomInformation(selectedRoomId);
                var roomType = roomTypeService.getRoomType(roomInfomation.RoomTypeId);
                roomInfomation.RoomType = roomType;

                toom_Id.Content = roomInfomation.RoomId.ToString();
                txtRoom_number.Content = roomInfomation.RoomNumber.ToString();
                txtRoom_description.Content = roomInfomation.RoomDetailDescription.ToString();
                txtRoom_Maxcapacity.Content = roomInfomation.RoomMaxCapacity.ToString();
                txt_priceperday.Content = roomInfomation.RoomPricePerDay.ToString();
                txtRoom_typeName.Content = roomInfomation.RoomType.RoomTypeName.ToString();
                txt_typeNote.Content = roomInfomation.RoomType.TypeNote.ToString();
                txt_typeDescription.Text = roomInfomation.RoomType.TypeDescription.ToString();

            }
            
            
            
        }

        private void btn_booking_Click(object sender, RoutedEventArgs e)
        {
            var selectedRoom = (sender as FrameworkElement).DataContext as RoomInformation;
            if (Application.Current.Properties["Customer"] as Customer != null)
            {
                NavigationService.Navigate(new Uri("BookingCustomerPage.xaml", UriKind.Relative));
            }
            else
            {
                Application.Current.Properties["SelectedRoomId"] = selectedRoom.RoomId;
                NavigationService.Navigate(new Uri("AdminBookingForCustomerPage.xaml", UriKind.Relative));
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("HomeCustomerPage.xaml", UriKind.Relative));
        }
    }
}
