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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            frMain.Navigate(new HomeAdmin());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new HomeAdmin());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["Customer"] = null;
            this.Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new AdminManagerCustomerPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new AdminManagerBookingResevationPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new ReportPage());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new ManagerRoomPage());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = true;
        }

        private void frMain_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
