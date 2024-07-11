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
    /// Interaction logic for ViewAndUpdateRoomPage.xaml
    /// </summary>
    public partial class ViewAndUpdateRoomPage : Page
    {
        private IRoomInfomationService roomInfomationService;
        private IRoomTypeService roomTypeService;
        public ViewAndUpdateRoomPage()
        {

            InitializeComponent();
            roomInfomationService = new RoomInformationService();
            roomTypeService = new RoomTypeService();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            combobox_fillter.ItemsSource = roomTypeService.listRoomType();

            var idRoom = Application.Current.Properties["roomId"].ToString();
            var roomInfor=roomInfomationService.GetRoomInformation(Int32.Parse(idRoom));
            txt_id.Text=roomInfor.RoomId.ToString();
            txt_roomNumber.Text=roomInfor.RoomNumber.ToString();
            txt_roomMaxCapacity.Text = roomInfor.RoomMaxCapacity.ToString();
            txt_pricePerDay.Text= roomInfor.RoomPricePerDay.ToString();
            txt_description.Text = roomInfor.RoomDetailDescription.ToString();
            var roomType = roomTypeService.getRoomType(roomInfor.RoomTypeId);
            if (roomType == null)
            {
                MessageBox.Show("1");
            }

            txt_fakeRoomType.Content = roomType.RoomTypeName;

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("ManagerRoomPage.xaml", UriKind.Relative));
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Do you want Update", "Comfim", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) {
                string roomId = txt_id.Text;
                string roomNumber = txt_roomNumber.Text;
                string maxCapacity = txt_roomMaxCapacity.Text;
                string pricePerDay = txt_pricePerDay.Text;
                string roomtype = null;
                string description = txt_description.Text;

                if ((combobox_fillter.SelectedValue != null))
                {
                    roomtype = combobox_fillter.SelectedValue.ToString();
                }
                else
                {
                    roomtype = txt_fakeRoomType.Content.ToString();
                }
                RoomType findRoomtype = roomTypeService.getRoomTypeByName(roomtype);

                RoomInformation updateRoomInfor = new RoomInformation();
                updateRoomInfor.RoomId = Int32.Parse(roomId);
                updateRoomInfor.RoomNumber = roomNumber;
                updateRoomInfor.RoomMaxCapacity = Int32.Parse(maxCapacity);
                updateRoomInfor.RoomPricePerDay = Decimal.Parse(pricePerDay);
                updateRoomInfor.RoomTypeId =findRoomtype.RoomTypeId;
                updateRoomInfor.RoomStatus = 1;
                updateRoomInfor.RoomDetailDescription = description;

                if (roomInfomationService.UpdateInformation(updateRoomInfor))
                {
                    MessageBox.Show("Update success");
                }
                else
                {
                    MessageBox.Show("Update false");
                }


            }
            else
            {
                
            }
        }

        private void combobox_fillter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combobox_fillter.SelectedValue != null)
            {
                txt_fakeRoomType.Visibility = Visibility.Collapsed;
            }
            else
            {
                txt_fakeRoomType.Visibility = Visibility.Visible;
            }
        }

        private void txt_fakeRoomType_MouseDown(object sender, MouseButtonEventArgs e)
        {
            combobox_fillter.Focus();
        }
    }
}
