using CA_EcommerceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EcommerceDB.Repositories
{
    internal interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        string AddCustomer(Customer customer);
        string UpdateCustomer(Customer customer);
        string DeleteCustomer(int id);
    }
}
