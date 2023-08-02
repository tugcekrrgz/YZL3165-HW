using CA_EcommerceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EcommerceDB.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        ECommerceDbContext db = new ECommerceDbContext();
        public string AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return "Müşteri Eklendi.";
        }

        public string DeleteCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return "Müşteri Silindi.";
        }

        public List<Customer> GetCustomers()
        {
            var customers=db.Customers.ToList();
            return customers;
        }

        public string UpdateCustomer(Customer customer)
        {
            db.Customers.Update(customer);
            db.SaveChanges();
            return "Müşteri Güncellendi.";
        }
    }
}
