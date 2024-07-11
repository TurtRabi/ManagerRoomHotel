using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerService
    {
        public List<Customer> getListCustomer();
        public Customer getCustomerById(int id);
        public Customer getCustomerByNameAndPhone(string name,string phone);
        public bool addCustomer(Customer customer);
        public bool updateCustomer(Customer customer);
        public void deleteCustomer(int id);
        public Customer authCustomer(String email, String password);
    }
}
