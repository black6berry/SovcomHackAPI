using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class CreditCard
{
    /// <summary>
    /// ИД
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// ИД типа карты (зарплатная, кредитная)
    /// </summary>
    public long TypeCardId { get; set; }

    /// <summary>
    /// Номер карты
    /// </summary>
    public string Number { get; set; } = null!;

    /// <summary>
    /// День действителен ДО
    /// </summary>
    public long Day { get; set; }

    /// <summary>
    /// Год действителен ДО
    /// </summary>
    public long Year { get; set; }

    /// <summary>
    /// Код CVV
    /// </summary>
    public long Cvv { get; set; }

    /// <summary>
    /// Дата, до которой нужно карту обновить
    /// </summary>
    public DateTime DateOfReceiving { get; set; }

    /// <summary>
    /// Объем денег на карте (Мы понимаем, что должен быть счет и должен быть привязана карта к нему, а деньги на счету, но чтобы сэкономить время - вы сразу деньги храним на карте)
    /// </summary>
    public decimal ValueMoney { get; set; }

    public virtual ICollection<BankAccAvailable> BankAccAvailables { get; } = new List<BankAccAvailable>();

    public virtual TypeCard TypeCard { get; set; } = null!;
}
