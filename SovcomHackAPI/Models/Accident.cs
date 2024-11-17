using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class Accident
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
    /// ИД Категория травмоопасности
    /// </summary>
    public long CategoryId { get; set; }

    /// <summary>
    /// Получаемое значение
    /// </summary>
    public decimal ValueGet { get; set; }

    /// <summary>
    /// Дата происшествия
    /// </summary>
    public DateTime DateAccident { get; set; }

    /// <summary>
    /// Координата по Ox
    /// </summary>
    public decimal GeoposionX { get; set; }

    /// <summary>
    /// Координата по OY
    /// </summary>
    public decimal GeoposionY { get; set; }

    /// <summary>
    /// ИД сессии, когда произошло происшествие
    /// </summary>
    public long SessionId { get; set; }

    public virtual CategoryAccident Category { get; set; } = null!;

    public virtual SessionUserBidding Session { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
