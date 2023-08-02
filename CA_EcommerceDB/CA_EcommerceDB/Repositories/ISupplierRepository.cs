using CA_EcommerceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_EcommerceDB.Repositories
{
    internal interface ISupplierRepository
    {
        List<Supplier> GetSuppliers();
        string AddSupplier(Supplier supplier);
        string DeleteSupplier(int id);
        string UpdateSupplier(Supplier supplier);
    }
}
