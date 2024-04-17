using System;
using System.Collections.Generic;

namespace API1.Models;

public partial class Product
{
    public int Id { get; set; }

    public int IdCategory { get; set; }

    public int IdBrand { get; set; }

    public int Quantity { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Size { get; set; }

    public virtual Brand IdBrandNavigation { get; set; } = null!;

    public virtual ProductCategory IdCategoryNavigation { get; set; } = null!;

    public virtual ICollection<ProductsFromTheReceipt> ProductsFromTheReceipts { get; set; } = new List<ProductsFromTheReceipt>();
}
