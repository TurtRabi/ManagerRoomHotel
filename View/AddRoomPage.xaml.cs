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
    /// Interaction logic for AddRoomPage.xaml
    /// </summary>
    public partial class AddRoomPage : Page
    {
        private IRoomTypeService roomTypeService;
        private IRoomInfomationService roomInfomationService;
        public AddRoomPage()
        {
            InitializeComponent();
            roomTypeService = new RoomTypeService();
            roomInfomationService= new RoomInformationService();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listRoomType.ItemsSource = roomTypeService.listRoomType();
        }

        private void btn_SignUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("ManagerRoomPage.xaml", UriKind.Relative));
        }

        private void combobox_fillter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_AddRoom_Click(object sender, RoutedEventArgs e)
        {
            string roomNumber = txt_roomNumber.Text;
            string roomMaxCapaCity = txt_RoomMaxCapacity.Text;
            string roomDetalDisription = txt_RoomDetailDescription.Text;
            string pricePerDay = txt_pricePerDay.Text;
            bool? roomStatus = txt_roomStatus.IsEnabled;
            byte? roomSt = 0;
            if (roomStatus==true)
            {
                roomSt = 1;
            }
            else
            {
                roomSt = 0;
            }
            int roomId = 0;
            if (listRoomType.SelectedItem is RoomType selectedRoomType)
            {
                roomId= selectedRoomType.RoomTypeId;
            }
            
           

            RoomInformation roomInformation = new RoomInformation();

            roomInformation.RoomNumber = roomNumber;
            
            roomInformation.RoomMaxCapacity = Int32.Parse(roomMaxCapaCity);
            
            roomInformation.RoomDetailDescription = roomDetalDisription;

           
            roomInformation.RoomStatus = roomSt;
            decimal resultPriceperday = 0;
            decimal.TryParse(pricePerDay, out resultPriceperday);
            roomInformation.RoomPricePerDay = resultPriceperday;
            roomInformation.RoomTypeId = roomId;
            //RoomInformationDAO roomInformationDAO = new RoomInformationDAO();
            if (roomInfomationService.AddInfomationService(roomInformation))
            {
                MessageBox.Show("Add Success");
            }
            else
            {
                MessageBox.Show("add False");

            }
            NavigationService.Navigate(new Uri("ManagerRoomPage.xaml", UriKind.Relative));
        }
    }
}
