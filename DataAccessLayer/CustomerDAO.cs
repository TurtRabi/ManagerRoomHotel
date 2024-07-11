using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
       
        public static List<Customer> listAllCustomer()
        {
            using var context = new FuminiHotelManagementContext();
            return context.Customers.ToList();
        }

        public static Customer GetCustomerById(int id) {
            using var context = new FuminiHotelManagementContext();
            return context.Customers.SingleOrDefault(c => c.CustomerId.Equals(id));
        }

        public static bool addCustomer(Customer customer) {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Customers.Add(customer);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex) { 
                return false;
            }
        }

        public static void disableCustomer(int id)
        {
            using var context = new FuminiHotelManagementContext();
            Customer customer = context.Customers.SingleOrDefault(c=>c.CustomerId.Equals(id));
            Customer customer1 = customer;
            customer1.CustomerStatus = 0;
            context.Entry(customer).CurrentValues.SetValues(customer1);
            context.SaveChanges() ;
        }

        public static Boolean updateCustomer(Customer customer )
        {
            using var context = new FuminiHotelManagementContext();
            var findCustomer = context.Customers.Find(customer.CustomerId);
            if (findCustomer != null)
            {
                context.Entry(findCustomer).CurrentValues.SetValues(customer);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Customer authCustomer(String email, String password)
        {
            using var context = new FuminiHotelManagementContext();
            var authCustomer= context.Customers.SingleOrDefault(c=>c.EmailAddress.Equals(email)&&c.Password.Equals(password));
            if (authCustomer != null) { 
                return authCustomer;
            }
            else
            {
                return null;
            }

        }

        public static Customer GetCustomerByNameAndPhone(string name, string phone)
        {
            using var context = new FuminiHotelManagementContext();
            return context.Customers.FirstOrDefault(c => c.CustomerFullName.Equals(name)&&c.Telephone.Equals(phone));
        }

    }
}
