using SovcomHackAPI.Models;

namespace SovcomHackAPI.ActionClass
{
    public class GenerationCardClass
    {
        public static CreditCard GetDataCreditCard()  => new CreditCard()
        {
            TypeCardId = 2,
            Number = $"{new Random().Next(2200, 2299)}{new Random().Next(1000, 5000)}{new Random().Next(1000, 5000)}{new Random().Next(1000, 5000)}",
            Day = Convert.ToInt64(DateTime.Now.Day),
            Year = long.Parse(DateTime.Now.Year.ToString().Remove(0,2))+2,
            Cvv = new Random().Next(100, 999),
            DateOfReceiving = DateTime.Now.AddYears(2),
            ValueMoney = 0
        };
    }
}
