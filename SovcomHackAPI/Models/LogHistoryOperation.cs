using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class LogHistoryOperation
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long BankAccountClientId { get; set; }

    public DateTime Date { get; set; }

    public int OperationId { get; set; }

    public bool IsLoad { get; set; }

    public decimal ValueMoney { get; set; }

    public virtual BankAccountClient BankAccountClient { get; set; } = null!;

    public virtual Operation Operation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
