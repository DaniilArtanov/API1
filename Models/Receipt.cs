using System;
using System.Collections.Generic;

namespace API1.Models;

public partial class Receipt
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int Price { get; set; }

    public DateTime Date { get; set; }

    public int QualinitiEPoint { get; set; }

    public virtual ICollection<ProductsFromTheReceipt> ProductsFromTheReceipts { get; set; } = new List<ProductsFromTheReceipt>();
}
