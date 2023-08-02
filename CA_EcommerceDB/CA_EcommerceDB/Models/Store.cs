using System;
using System.Collections.Generic;

namespace CA_EcommerceDB.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string StoreName { get; set; } = null!;

    public string StoreAddress { get; set; } = null!;

    public string StorePhoneNumber { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
