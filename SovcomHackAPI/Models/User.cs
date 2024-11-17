using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class User
{
    /// <summary>
    /// ИД
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; } = null!;

    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronomic { get; set; } = null!;

    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; set; } = null!;

    /// <summary>
    /// Последнее подключение
    /// </summary>
    public DateTime LastConnect { get; set; }

    /// <summary>
    /// ИД роли пользователя
    /// </summary>
    public long RoleId { get; set; }

    /// <summary>
    /// Подтверждение аккаунта пользователя
    /// </summary>
    public bool Verified { get; set; }

    /// <summary>
    /// Статус пользователя
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; set; } = null!;

    public virtual ICollection<Accident> Accidents { get; } = new List<Accident>();

    public virtual ICollection<ActiveBag> ActiveBags { get; } = new List<ActiveBag>();

    public virtual ICollection<BankAccountClient> BankAccountClients { get; } = new List<BankAccountClient>();

    public virtual ICollection<LogHistoryOperation> LogHistoryOperations { get; } = new List<LogHistoryOperation>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SessionUserBidding> SessionUserBiddings { get; } = new List<SessionUserBidding>();
}
