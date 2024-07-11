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
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {

        private IRoomInfomationService roomInfomationService;
        public CustomerWindow()
        {
            InitializeComponent();
            roomInfomationService = new RoomInformationService();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var listdata = roomInfomationService.listRoomInfomation();
           
            var customer = Application.Current.Properties["Customer"] as Customer;
            
            userName.Content = customer.CustomerFullName.ToString();
            frMain.Navigate(new HomeCustomerPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowPopup_Click(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = true;

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = false;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["Customer"] = null;
            this.Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new InforPage());
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new BookingHistoryPage());
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new HomeCustomerPage());
        }

        private void frMain_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
