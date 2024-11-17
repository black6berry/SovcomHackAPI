using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class ActiveBag
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public string? Name { get; set; }

    public decimal? Value { get; set; }

    public DateTime? LastDateUpdate { get; set; }

    public virtual User? User { get; set; }
}
