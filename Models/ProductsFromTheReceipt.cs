using System;
using System.Collections.Generic;

namespace API1.Models;

public partial class ProductsFromTheReceipt
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public int IdReceipt { get; set; }

    public int Qualiniti { get; set; }

    public int Price { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Receipt IdReceiptNavigation { get; set; } = null!;
}
