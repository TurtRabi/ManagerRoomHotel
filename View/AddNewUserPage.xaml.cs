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
    /// Interaction logic for AddNewUserPage.xaml
    /// </summary>
    public partial class AddNewUserPage : Page
    {
        private ICustomerService customerService;
        public AddNewUserPage()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn_SignUp_Click(object sender, RoutedEventArgs e)
        {
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string numberPhone = txtPhone.Text;
            string password = txtPassword.Password;
            DateTime? birtdate = txtbirtDay.SelectedDate;

            Customer customer = new Customer();
            customer.Telephone = numberPhone;
            customer.CustomerFullName = fullName;
            customer.CustomerBirthday = DateOnly.FromDateTime(birtdate.Value);
            customer.EmailAddress = email;
            customer.Password = password;
            customer.CustomerStatus = 1;
            if (customerService.addCustomer(customer))
            {
                MessageBox.Show("Register Success");
                NavigationService.Navigate(new Uri("AdminManagerCustomerPage.xaml", UriKind.Relative));
                ResetForm();
            }
            else
            {
                MessageBox.Show("Register Fail");
            }
        }

        private void ResetForm()
        {
            txtFullName.Text = null;
            txtEmail.Text = null;
            txtPhone.Text = null;
            txtPassword.Password = null;
            txtbirtDay.SelectedDate = null;
            txtRePassword = null;
        }

        private void textFullName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtFullName.Focus();
        }

        private void txtFullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFullName.Text) && txtFullName.Text.Length > 0)
            {
                textFullName.Visibility = Visibility.Collapsed;
            }
            else
            {
                textFullName.Visibility = Visibility.Visible;
            }
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
            {
                textEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                textEmail.Visibility = Visibility.Visible;
            }
        }

        private void textPhone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPhone.Focus();
        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPhone.Text) && txtPhone.Text.Length > 0)
            {
                textPhone.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPhone.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }

            if (txtRePassword.Password.Equals(txtPassword.Password))
            {
                txtPassword.Background = System.Windows.Media.Brushes.LightGreen;
            }
            else
            {
                txtPassword.Background = System.Windows.Media.Brushes.LightCoral;
            }
        }

        private void textRePassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtRePassword.Focus();
        }

        private void txtRePassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRePassword.Password) && txtRePassword.Password.Length > 0)
            {
                textRePassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textRePassword.Visibility = Visibility.Visible;
            }

            if (txtRePassword.Password.Equals(txtPassword.Password))
            {
                txtRePassword.Background = System.Windows.Media.Brushes.LightGreen;
            }
            else
            {
                txtRePassword.Background = System.Windows.Media.Brushes.LightCoral;
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("AdminManagerCustomerPage.xaml", UriKind.Relative));
        }
    }
}
