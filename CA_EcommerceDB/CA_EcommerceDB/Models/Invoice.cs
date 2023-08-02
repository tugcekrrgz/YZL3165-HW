using System;
using System.Collections.Generic;

namespace CA_EcommerceDB.Models;

public partial class Invoice
{
    public int InvoicesId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateTime InvoiceCreationDate { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Order Invoices { get; set; } = null!;
}
