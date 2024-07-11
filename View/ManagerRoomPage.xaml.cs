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
    /// Interaction logic for ManagerRoomPage.xaml
    /// </summary>
    public partial class ManagerRoomPage : Page
    {
        private IRoomInfomationService roomInfomationService;
        private IRoomTypeService roomTypeService;
        List<RoomInformation> listRoomInfor=new List<RoomInformation>();
        public ManagerRoomPage()
        {
            InitializeComponent();
            roomInfomationService = new RoomInformationService();
            roomTypeService = new RoomTypeService();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listRoomInfor = roomInfomationService.listRoomInfomation();
            var listRoomType = roomTypeService.listRoomType();
            foreach (RoomInformation room in listRoomInfor) {
                foreach(RoomType type in listRoomType)
                {
                    if (room.RoomTypeId == type.RoomTypeId) {
                        room.RoomType = type;
                    }
                }
            }
            ListRoom.ItemsSource = listRoomInfor;
            combobox_fillter.ItemsSource = listRoomType;
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            var combobox = combobox_fillter.SelectedValue as RoomType;
            string search_txt = txt_SearchName.Text;
            if(search_txt.Length > 0 &&search_txt.Trim()!=""&& combobox==null)
            {
                var findList= listRoomInfor.Where(c=>c.RoomNumber.ToString().Contains(search_txt)).ToList();
                ListRoom.ItemsSource = findList;
            }else if(search_txt.Trim() == "" && combobox != null)
            {
                
                var findList = listRoomInfor.Where(c => c.RoomType.RoomTypeName.ToString().Equals(combobox.RoomTypeName)).ToList();
                ListRoom.ItemsSource = findList;
            }
            else if (search_txt.Trim() != "" && combobox != null)
            {

                var findList = listRoomInfor.Where(c => c.RoomType.RoomTypeName.ToString().Equals(combobox.RoomTypeName)&& c.RoomNumber.ToString().Contains(search_txt)).ToList();
                ListRoom.ItemsSource = findList;
            }
            else
            {
                ListRoom.ItemsSource = listRoomInfor;
            }
        }

        private void ListRoomtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want Disable?", "Comfim", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Button button = sender as Button;
                var view = button.DataContext as RoomInformation;
                if (view != null)
                {
                    roomInfomationService.DeleteRoomInformation(view.RoomId);

                    Page_Loaded(sender, e);


                }
            }
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var view = button.DataContext as RoomInformation;
            if (view != null) {
                Application.Current.Properties["roomId"] = view.RoomId;
                NavigationService.Navigate(new Uri("ViewAndUpdateRoomPage.xaml", UriKind.Relative));
            }

           


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want Enable?", "Comfim", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Button button = sender as Button;
                var view = button.DataContext as RoomInformation;
                if (view != null)
                {
                    roomInfomationService.EnableeRoomInformation(view.RoomId);

                    Page_Loaded(sender, e);


                }
            }
        }

        private void text_maxPrice_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void combobox_fillter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void text_change_MouseDown(object sender, MouseButtonEventArgs e)
        {
            combobox_fillter.Focus();
        }

        private void combobox_fillter_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (combobox_fillter.SelectedValue != null)
            {
                text_change.Visibility = Visibility.Collapsed;
            }
            else
            {
                text_change.Visibility = Visibility.Visible;
            }
        }

        private void text_change_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            txt_SearchName.Focus();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AddRoomPage.xaml", UriKind.Relative));
        }
    }
}
