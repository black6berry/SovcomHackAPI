using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class CheckMoneyDatum
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<BankAccountClient> BankAccountClients { get; } = new List<BankAccountClient>();
}
