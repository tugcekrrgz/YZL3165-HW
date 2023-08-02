using CA_EcommerceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EcommerceDB.Repositories
{
    internal class StoreRepository : IStoreRepository
    {
        ECommerceDbContext db=new ECommerceDbContext();
        public string AddStore(Store store)
        {
            db.Stores.Add(store);
            db.SaveChanges();
            return "Mağaza Eklendi.";
        }

        public string DeleteStore(int id)
        {
            var store=db.Stores.Find(id);
            db.Stores.Remove(store);
            db.SaveChanges();
            return "Mağaza Silindi.";
        }

        public List<Store> GetStores()
        {
            var stores = db.Stores.ToList();
            return stores;
        }

        public string UpdateStore(Store store)
        {
            db.Stores.Update(store);
            db.SaveChanges();
            return "Mağaza Güncellendi.";
        }
    }
}
