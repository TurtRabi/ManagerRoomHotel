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
    /// Interaction logic for InforPage.xaml
    /// </summary>
    public partial class InforPage : Page
    {
        private ICustomerService customerService;

        public InforPage()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want Update", "Comfim", MessageBoxButton.YesNo, MessageBoxImage.Question);
            string fullName = txt_fullName.Text;
            string phone = txt_phone.Text;
            var customer = new Customer();
            if(Application.Current.Properties["Customer"] as Customer != null)
            {
                customer = Application.Current.Properties["Customer"] as Customer;
            }
            else
            {
                string customerId = Application.Current.Properties["CustomerId"].ToString();
                customer = customerService.getCustomerById(Int32.Parse(customerId));
            }

            DateTime? birtdate = txt_birtday.SelectedDate;

            string passworld = customer.Password;
            string email = txt_email.Text;
            if (result == MessageBoxResult.Yes)
            {
                Customer update = new Customer();
                update.CustomerId = Int32.Parse(txt_id.Text);
                update.CustomerFullName = fullName;
                update.EmailAddress = email;
                update.Telephone = phone;
                update.CustomerBirthday = DateOnly.FromDateTime(birtdate.Value);
                update.Password = passworld;
                update.CustomerStatus = 1;
                if (customerService.updateCustomer(update))
                {
                    MessageBox.Show("Update success!!!");
                    
                    
                    Page_Loaded(sender, e);
                    Application.Current.Properties["CustomerId"] = null;
                    //Application.Current.Properties["Customer"] = null ;

                }
                else
                {
                    MessageBox.Show("Update false" +
                        "!!!");
                }
                
                
            }
            else
            {
                
            }
            

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var findCustomer = new Customer();
            if (Application.Current.Properties["Customer"] as Customer!=null)
            {
                var customer = Application.Current.Properties["Customer"] as Customer;
                findCustomer = customerService.getCustomerById(customer.CustomerId);
                txt_id.Text = findCustomer.CustomerId.ToString();
                txt_fullName.Text = findCustomer.CustomerFullName;
                txt_phone.Text = findCustomer.Telephone;
                txt_birtday.Text = findCustomer.CustomerBirthday.ToString();
                txt_email.Text = findCustomer.EmailAddress.ToString();

            }
            else
            {
                string customerId = Application.Current.Properties["CustomerId"].ToString();
                findCustomer = customerService.getCustomerById(Int32.Parse(customerId));
                txt_id.Text = findCustomer.CustomerId.ToString();
                txt_fullName.Text = findCustomer.CustomerFullName;
                txt_phone.Text = findCustomer.Telephone;
                txt_birtday.Text = findCustomer.CustomerBirthday.ToString();
                txt_email.Text = findCustomer.EmailAddress.ToString();
            }
          
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Properties["Customer"]!=null)
            {
                NavigationService.Navigate(new Uri("HomeCustomerPage.xaml", UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("AdminManagerCustomerPage.xaml", UriKind.Relative));
            }
        }
    }
}
