using System;
using System.Collections.Generic;

namespace CA_EcommerceDB.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerFirstName { get; set; } = null!;

    public string CustomerLastName { get; set; } = null!;

    public string CustomerEmailAddress { get; set; } = null!;

    public string CustomerPhoneNumber { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
