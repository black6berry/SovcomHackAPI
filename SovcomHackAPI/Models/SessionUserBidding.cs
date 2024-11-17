using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class SessionUserBidding
{
    /// <summary>
    /// ИД
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// ИД Пользователя
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Время начала (момент, когда тумблер true)
    /// </summary>
    public long TimeSpanActive { get; set; }

    /// <summary>
    /// Время конца (момент, когда тумблер false)
    /// </summary>
    public long TimeSpanFinish { get; set; }

    /// <summary>
    /// ИД Продукта компании
    /// </summary>
    public long Get { get; set; }

    public virtual ICollection<Accident> Accidents { get; } = new List<Accident>();

    public virtual User User { get; set; } = null!;
}
