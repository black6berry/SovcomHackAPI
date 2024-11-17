using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class Operation
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<LogHistoryOperation> LogHistoryOperations { get; } = new List<LogHistoryOperation>();
}
