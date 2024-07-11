using BusinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepositpry : ICustomerRepositpry
    {
        public bool addCustomer(Customer customer) => CustomerDAO.addCustomer(customer);

        public Customer authCustomer(string email, string password)=>CustomerDAO.authCustomer(email, password);
        
        public void deleteCustomer(int id)=>CustomerDAO.disableCustomer(id);
        
        public Customer getCustomerById(int id)=> CustomerDAO.GetCustomerById(id);

        public Customer getCustomerByNameAndPhone(string name, string phone)=>CustomerDAO.GetCustomerByNameAndPhone(name, phone);

        public List<Customer> getListCustomer()=>CustomerDAO.listAllCustomer();
        
        public bool updateCustomer(Customer customer)=>CustomerDAO.updateCustomer(customer);
        
    }
}
