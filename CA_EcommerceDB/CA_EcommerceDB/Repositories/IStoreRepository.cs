using CA_EcommerceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EcommerceDB.Repositories
{
    internal interface IStoreRepository
    {
        List<Store> GetStores();
        string AddStore(Store store);
        string DeleteStore(int id);
        string UpdateStore(Store store);
    }
}
