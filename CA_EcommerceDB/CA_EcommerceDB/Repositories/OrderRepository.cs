using CA_EcommerceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EcommerceDB.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        ECommerceDbContext db = new ECommerceDbContext();
        public string AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return "Sipariş Eklendi.";
        }

        public string DeleteOrder(int id)
        {
            var order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return "Sipariş Silindi.";
        }

        public List<Order> GetOrders()
        {
            var orders=db.Orders.ToList();
            return orders;
        }

        public string UpdateOrder(Order order)
        {
            db.Orders.Update(order);
            db.SaveChanges();
            return "Sipariş Güncellendi.";
        }
    }
}
