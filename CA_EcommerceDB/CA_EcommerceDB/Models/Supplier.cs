using System;
using System.Collections.Generic;

namespace CA_EcommerceDB.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string SupplierAddress { get; set; } = null!;

    public string SupplierPhoneNumber { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
