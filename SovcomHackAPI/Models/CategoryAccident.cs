using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class CategoryAccident
{
    /// <summary>
    /// ИД
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название категории
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Описание категории
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Какие угрозы жизни
    /// </summary>
    public string Effects { get; set; } = null!;

    /// <summary>
    /// Диапазон ОТ
    /// </summary>
    public decimal RangeFrom { get; set; }

    /// <summary>
    /// Диапазон ДО
    /// </summary>
    public decimal RangeTo { get; set; }

    public virtual ICollection<Accident> Accidents { get; } = new List<Accident>();
}
