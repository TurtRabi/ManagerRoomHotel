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
    /// Interaction logic for AdminManagerCustomerPage.xaml
    /// </summary>
    public partial class AdminManagerCustomerPage : Page
    {
        private ICustomerService customerService;
        private List<Customer> customerList;


        public AdminManagerCustomerPage()
        {
            InitializeComponent();
            customerService = new CustomerService();
            customerList = customerService.getListCustomer();
        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListCustomer.ItemsSource = customerService.getListCustomer();
        }

        private void ListRoomtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var view = button.DataContext as Customer;
            Application.Current.Properties["CustomerId"] = view.CustomerId;
            NavigationService.Navigate(new Uri("InforPage.xaml", UriKind.Relative));
        }

      
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var view = button.DataContext as Customer;
            Application.Current.Properties["CustomerId"] = view.CustomerId;
            
            MessageBoxResult result = MessageBox.Show("Do you want Delete?", "Comfim", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                customerService.deleteCustomer(view.CustomerId);
                ListCustomer.ItemsSource = customerService.getListCustomer();
                MessageBox.Show("Delete Success");
            }
            else
            {
                MessageBox.Show("Delete False");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AddNewUserPage.xaml", UriKind.Relative));
        }

        private void text_maxPrice_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txt_SearchName.Focus();
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

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            var search = txt_SearchName.Text;
            bool? enable = txtEnable.IsChecked;
            bool? disable = txtIsDisable.IsChecked;
            if (search.Trim() != "" && enable==false&&disable==false)
            {
                customerList= customerService.getListCustomer();
                var listCustomerFillter = customerList.Where(c => c.CustomerFullName.Contains(search)).ToList();
                ListCustomer.ItemsSource = listCustomerFillter;
                
            }else if (search.Trim() != "" && enable == true && disable == false)
            {
                customerList = customerService.getListCustomer();
                var listCustomerFillter = customerList.Where(c => c.CustomerFullName.Contains(search)&&c.CustomerStatus==1).ToList();
                ListCustomer.ItemsSource = listCustomerFillter;
            }else if(search.Trim() != "" && enable == false && disable == true)
            {
                customerList = customerService.getListCustomer();
                var listCustomerFillter = customerList.Where(c => c.CustomerFullName.Contains(search) && c.CustomerStatus == 0).ToList();
                ListCustomer.ItemsSource = listCustomerFillter;
            }else if (search.Trim() == "" && enable == true && disable == false)
            {
                customerList = customerService.getListCustomer();
                var listCustomerFillter = customerList.Where(c => c.CustomerStatus == 1).ToList();
                ListCustomer.ItemsSource = listCustomerFillter;
            }else if(search.Trim() == "" && enable == false && disable == true)
            {
                customerList = customerService.getListCustomer();
                var listCustomerFillter = customerList.Where(c => c.CustomerStatus == 0).ToList();
                ListCustomer.ItemsSource = listCustomerFillter;
            }
            else
            {
                customerList = customerService.getListCustomer();
                ListCustomer.ItemsSource = customerList;
            }
        }

        private void txtStatus_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AddNewUserPage.xaml", UriKind.Relative));
        }
    }
}
