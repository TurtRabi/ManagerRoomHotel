using BusinessObject.Models;
using Microsoft.Extensions.Configuration;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private ICustomerService customerService;

        private string getAdminEmail()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true).Build();
            return configuration["HotelSystemSettings:AdminEmail"];
        }

        private string getAdminPassword()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true).Build();
            return configuration["HotelSystemSettings:AdminPassword"];
        }
        public LoginWindow()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        private void btn_SignUp_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
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
        }

        private void btn_SignIn_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            Customer customer = customerService.authCustomer(email, password);
            if (email.Equals(getAdminEmail()) && password.Equals(getAdminPassword()))
            {
                this.Hide();
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }else if (customer!=null&& customer.CustomerStatus==1)
            {
                this.Hide();
                Application.Current.Properties["Customer"] = customer;
                CustomerWindow customerWindow = new CustomerWindow();
                customerWindow.Show();
            }
            else
            {
                MessageBox.Show("Email or Password invalid!!");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
