using CA_EcommerceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EcommerceDB.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        ECommerceDbContext db = new ECommerceDbContext();
        public string AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return "Ürün Eklendi.";
        }

        public string DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return "Ürün Silindi.";
        }

        public List<Product> GetProducts()
        {
            var products = db.Products.ToList();
            return products;
        }

        public string UpdateProduct(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
            return "Ürün Güncellendi.";
        }
    }
}
