using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerRepositpry
    {
        public List<Customer> getListCustomer();
        public Customer getCustomerById(int id);
        public bool addCustomer(Customer customer);
        public bool updateCustomer(Customer customer);
        public void deleteCustomer(int id);
        public Customer authCustomer(String email,String password);
        public Customer getCustomerByNameAndPhone(string name,String phone);
    }
}
