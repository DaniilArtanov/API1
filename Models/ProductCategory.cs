using System;
using System.Collections.Generic;

namespace API1.Models;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string NameCategory { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
