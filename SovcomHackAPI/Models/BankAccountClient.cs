using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class BankAccountClient
{
    /// <summary>
    /// ИД
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// ИД Клиента
    /// </summary>
    public long UserId { get; set; }

    public decimal ValueMoney { get; set; }

    public int CheckMoneyDataId { get; set; }

    public string Number { get; set; } = null!;

    public virtual ICollection<BankAccAvailable> BankAccAvailables { get; } = new List<BankAccAvailable>();

    public virtual CheckMoneyDatum CheckMoneyData { get; set; } = null!;

    public virtual ICollection<LogHistoryOperation> LogHistoryOperations { get; } = new List<LogHistoryOperation>();

    public virtual User User { get; set; } = null!;
}
