using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class BankAccAvailable
{
    public long Id { get; set; }

    public long BankAccountId { get; set; }

    public long CreditCardId { get; set; }

    public DateTime DateCreate { get; set; }

    public virtual BankAccountClient BankAccount { get; set; } = null!;

    public virtual CreditCard CreditCard { get; set; } = null!;
}
