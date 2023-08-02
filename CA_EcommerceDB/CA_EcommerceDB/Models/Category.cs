﻿using System;
using System.Collections.Generic;

namespace CA_EcommerceDB.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDefinition { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
