using BusinessObject.Models;
using Services;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for HomeCustomerPage.xaml
    /// </summary>
    public partial class HomeCustomerPage : Page
    {
        private IRoomTypeService roomTypeService;
        private IRoomInfomationService roomInfomationService;
        private List<RoomInformation> list_RoomInfomation;
        public HomeCustomerPage()
        {
            InitializeComponent();
            roomTypeService = new RoomTypeService();
            roomInfomationService = new RoomInformationService();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var list_roomType = roomTypeService.listRoomType();
            list_RoomInfomation = roomInfomationService.listRoomInfomation();
            foreach ( var roomType in list_roomType)
            {
                foreach(var roomInfomation in list_RoomInfomation)
                {
                    if(roomType.RoomTypeId == roomInfomation.RoomTypeId)
                    {
                        roomType.RoomInformations.Add(roomInfomation);
                        roomInfomation.RoomType = roomType;
                    }
                }
            }

            combobox_fillter.ItemsSource = list_roomType;

            ListRoomtype.ItemsSource = list_RoomInfomation;
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedRoom = (sender as FrameworkElement).DataContext as RoomInformation;
            if(selectedRoom != null)
            {
                Application.Current.Properties["SelectedRoomId"] = selectedRoom.RoomId;
                NavigationService.Navigate(new Uri("ViewPage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Please select a room.");
            }

            
        }
        private void combobox_fillter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combobox_fillter.SelectedValue!=null)
            {
                text_change.Visibility = Visibility.Collapsed;
            }
            else
            {
                text_change.Visibility = Visibility.Visible;
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            combobox_fillter.Focus();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            string maxPrice=txt_maxPrice.Text;
            string minPrice =txt_minPrice.Text;
            if (maxPrice.Trim() == "")
            {
                maxPrice = "";
            }
            if(minPrice.Trim() == "")
            {
                minPrice = "";
            }

            if (maxPrice != null && minPrice.Trim() == "")
            {
                decimal maxpriceD;
                CultureInfo culture = new CultureInfo("fr-FR");

                decimal.TryParse(maxPrice, NumberStyles.Number, culture, out maxpriceD);
                var listRoomInfomationByName = list_RoomInfomation.Where(c => c.RoomPricePerDay <= maxpriceD).ToList();
                ListRoomtype.ItemsSource = listRoomInfomationByName;

            }else if (minPrice != null && maxPrice.Trim() == "")
            {
                decimal minpriceD;
                CultureInfo culture = new CultureInfo("fr-FR");

                decimal.TryParse(minPrice, NumberStyles.Number, culture, out minpriceD);
                var listRoomInfomationByName = list_RoomInfomation.Where(c => c.RoomPricePerDay >= minpriceD).ToList();
                ListRoomtype.ItemsSource = listRoomInfomationByName;
            }
            else if(minPrice != null && maxPrice != null){
                decimal minpriceD;
                CultureInfo culture = new CultureInfo("fr-FR");
                decimal maxpriceD;
                decimal.TryParse(maxPrice, NumberStyles.Number, culture, out maxpriceD);
                decimal.TryParse(minPrice, NumberStyles.Number, culture, out minpriceD);

                var listRoomInfomationByName = list_RoomInfomation.Where(c => c.RoomPricePerDay >= minpriceD&& c.RoomPricePerDay<=maxpriceD).ToList();
                ListRoomtype.ItemsSource = listRoomInfomationByName;
            }
           
            if (combobox_fillter.SelectedItem is RoomType selectedRoomType && maxPrice.Trim() == "" && minPrice.Trim() == "")
            {
                int selectedRoomTypeId = 0;
                selectedRoomTypeId = selectedRoomType.RoomTypeId;
                if (selectedRoomTypeId != 0)
                {
                    var listRoomInfomationByRoomId = list_RoomInfomation.Where(c => c.RoomTypeId == selectedRoomTypeId).ToList();
                    ListRoomtype.ItemsSource = listRoomInfomationByRoomId;

                }
                else if (maxPrice != null && minPrice.Trim() == "" && selectedRoomTypeId != 0)
                {
                    decimal maxpriceD;
                    CultureInfo culture = new CultureInfo("fr-FR");

                    decimal.TryParse(maxPrice, NumberStyles.Number, culture, out maxpriceD);
                    var listRoomInfomationByName = list_RoomInfomation.Where(c => c.RoomPricePerDay <= maxpriceD && c.RoomTypeId == selectedRoomTypeId).ToList();
                    ListRoomtype.ItemsSource = listRoomInfomationByName;

                }
                else if (minPrice != null && maxPrice.Trim() == "" && selectedRoomTypeId != 0)
                {
                    decimal minpriceD;
                    CultureInfo culture = new CultureInfo("fr-FR");

                    decimal.TryParse(minPrice, NumberStyles.Number, culture, out minpriceD);
                    var listRoomInfomationByName = list_RoomInfomation.Where(c => c.RoomPricePerDay >= minpriceD && c.RoomTypeId == selectedRoomTypeId).ToList();
                    ListRoomtype.ItemsSource = listRoomInfomationByName;
                }
                else if (minPrice != null && maxPrice != null && selectedRoomTypeId != 0)
                {
                    decimal minpriceD;
                    CultureInfo culture = new CultureInfo("fr-FR");
                    decimal maxpriceD;
                    decimal.TryParse(maxPrice, NumberStyles.Number, culture, out maxpriceD);
                    decimal.TryParse(minPrice, NumberStyles.Number, culture, out minpriceD);

                    var listRoomInfomationByName = list_RoomInfomation.Where(c => c.RoomPricePerDay >= minpriceD && c.RoomPricePerDay <= maxpriceD && c.RoomTypeId == selectedRoomTypeId).ToList();
                    ListRoomtype.ItemsSource = listRoomInfomationByName;
                }
                else
                {
                    ListRoomtype.ItemsSource = list_RoomInfomation;
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRoom = (sender as FrameworkElement).DataContext as RoomInformation;
            if (Application.Current.Properties["Customer"] as Customer !=null)
            {
                if (selectedRoom != null)
                {
                    Application.Current.Properties["SelectedRoomId"] = selectedRoom.RoomId;
                    NavigationService.Navigate(new Uri("BookingCustomerPage.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Please select a room.");
                }
            }
            else
            {
                if(selectedRoom != null)
                {
                    Application.Current.Properties["SelectedRoomId"] = selectedRoom.RoomId;
                    NavigationService.Navigate(new Uri("AdminBookingForCustomerPage.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Please select a room.");
                }
            }
            
            
        }

        private void ListRoomtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void text_maxPrice_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txt_maxPrice.Focus();
        }

        private void text_minPrice_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void txt_maxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_maxPrice.Text) && txt_maxPrice.Text.Length > 0)
            {
                text_maxPrice.Visibility = Visibility.Collapsed;
            }
            else
            {
                text_maxPrice.Visibility = Visibility.Visible;
            }
        }

        private void txt_minPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_minPrice.Text) && txt_minPrice.Text.Length > 0)
            {
                text_minPrice.Visibility = Visibility.Collapsed;
            }
            else
            {
                text_minPrice.Visibility = Visibility.Visible;
            }
        }

        private void text_minPrice_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            txt_minPrice.Focus();
        }
    }
}
