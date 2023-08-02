using System;
using System.Collections.Generic;

namespace CA_EcommerceDB.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int OrderNumber { get; set; }

    public DateTime OrderCreationDate { get; set; }

    public DateTime OrderDeliveryDate { get; set; }

    public int CustomerId { get; set; }

    public int PaymentId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Invoice? Invoice { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
