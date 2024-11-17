using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class TypeCard
{
    /// <summary>
    /// ИД
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Тип карты
    /// </summary>
    public string Name { get; set; } = null!;

    public virtual ICollection<CreditCard> CreditCards { get; } = new List<CreditCard>();
}
