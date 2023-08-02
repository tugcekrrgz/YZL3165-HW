using CA_EcommerceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EcommerceDB.Repositories
{
    internal interface IOrderRepository
    {
        List<Order> GetOrders();
        string AddOrder(Order order);
        string UpdateOrder(Order order);
        string DeleteOrder(int id);
    }
}
