using System;
using System.Collections.Generic;

namespace CA_EcommerceDB.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int ProductPrice { get; set; }

    public string ProductDefinition { get; set; } = null!;

    public string ProductSize { get; set; } = null!;

    public string ProductColor { get; set; } = null!;

    public int CategoryId { get; set; }

    public int SupplierId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}
