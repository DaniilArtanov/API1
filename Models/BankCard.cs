using System;
using System.Collections.Generic;

namespace API1.Models;

public partial class BankCard
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public string CardNumber { get; set; } = null!;

    public int ValidityPeriod { get; set; }

    public int Cvc { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
