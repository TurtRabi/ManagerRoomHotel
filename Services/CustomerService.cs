using BusinessObject.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepositpry customerRepositpry;
        public CustomerService()
        {
            customerRepositpry = new CustomerRepositpry();
        }
        public bool addCustomer(Customer customer)=>customerRepositpry.addCustomer(customer);

        public Customer authCustomer(string email, string password)=>customerRepositpry.authCustomer(email, password);
        

        public void deleteCustomer(int id)=>customerRepositpry.deleteCustomer(id);
        

        public Customer getCustomerById(int id)=>customerRepositpry.getCustomerById(id);

        public Customer getCustomerByNameAndPhone(string name, string phone)
            =>customerRepositpry.getCustomerByNameAndPhone(name, phone);

        public List<Customer> getListCustomer()=>customerRepositpry.getListCustomer();
        

        public bool updateCustomer(Customer customer)=>customerRepositpry.updateCustomer(customer);
        
    }
}
