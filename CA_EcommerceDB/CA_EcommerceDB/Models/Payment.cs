using System;
using System.Collections.Generic;

namespace CA_EcommerceDB.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string PaymentType { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
