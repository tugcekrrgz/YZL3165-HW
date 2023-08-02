using CA_EcommerceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EcommerceDB.Repositories
{
    internal class SupplierRepository : ISupplierRepository
    {
        ECommerceDbContext db=new ECommerceDbContext();
        public string AddSupplier(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            db.SaveChanges();
            return "Tedarikçi Eklendi.";
        }

        public string DeleteSupplier(int id)
        {
            var supplier=db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
            return "Tedarikçi Silindi.";
        }

        public List<Supplier> GetSuppliers()
        {
            var suppliers = db.Suppliers.ToList();
            return suppliers;
        }

        public string UpdateSupplier(Supplier supplier)
        {
            db.Suppliers.Update(supplier);
            db.SaveChanges();
            return "Tedarikçi Güncellendi.";
        }
    }
}
