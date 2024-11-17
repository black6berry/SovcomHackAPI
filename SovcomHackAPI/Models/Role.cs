using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class Role
{
    /// <summary>
    /// ИД
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название роли
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Первая буква в названии роли
    /// </summary>
    public string NameFs { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
