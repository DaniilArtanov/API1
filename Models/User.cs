using System;
using System.Collections.Generic;

namespace API1.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<BankCard> BankCards { get; set; } = new List<BankCard>();
}
