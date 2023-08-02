using CA_EcommerceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EcommerceDB.Repositories
{
    internal interface IProductRepository
    {
        List<Product> GetProducts();
        string AddProduct(Product product);
        string UpdateProduct(Product product);
        string DeleteProduct(int id);
    }
}
