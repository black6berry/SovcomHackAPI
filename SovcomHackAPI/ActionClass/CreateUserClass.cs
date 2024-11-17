using SovcomHackAPI.ActionClass.User;
using SovcomHackAPI.Models;
using SovcomHackAPI.Interface;

namespace SovcomHackAPI.ActionClass
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    public class CreateUserClass : ICreateUser
    {
        private readonly SovcomHackContext _context;
        public CreateUserClass(SovcomHackContext context) => _context = context;

        public bool AddAccount(AccountCreate account)
        {
            try
            {
                var ChechMoneyData = _context.CheckMoneyData.ToArray();
                var TypeCard = _context.TypeCards.ToArray();
                var Role = _context.Roles.ToArray();

                Models.User createUser = new Models.User()
                {
                    Name = account.Name,
                    Surname = account.Surname,
                    Patronomic = account.Patronomic,
                    Phone = account.Phone,
                    LastConnect = DateTime.Now,
                    RoleId = 2,
                    Verified = false,
                    IsActive = true,
                    Login = account.Login,
                    Password = account.Password
                };

                _context.Users.Add(createUser);
                _context.SaveChanges();
                var idUser = _context.Users.OrderByDescending(x => x.Id).FirstOrDefault();

                CreditCard creditCard = new CreditCard()
                {
                    TypeCardId = GenerationCardClass.GetDataCreditCard().TypeCardId,
                    Number = GenerationCardClass.GetDataCreditCard().Number,
                    Day = GenerationCardClass.GetDataCreditCard().Day,
                    Year = GenerationCardClass.GetDataCreditCard().Year,
                    Cvv = GenerationCardClass.GetDataCreditCard().Cvv,
                    DateOfReceiving = GenerationCardClass.GetDataCreditCard().DateOfReceiving,
                    ValueMoney = GenerationCardClass.GetDataCreditCard().ValueMoney
                };

                _context.CreditCards.Add(creditCard);
                _context.SaveChanges();
                var idCreditCard = _context.CreditCards.OrderByDescending(x => x.Id).FirstOrDefault();

                BankAccountClient bankAccountClient = new BankAccountClient()
                {
                    UserId = idUser.Id,
                    ValueMoney = 0,
                    CheckMoneyDataId = 1,
                    Number = $"{new Random().Next(2200, 2299)}{new Random().Next(1000, 5000)}{new Random().Next(1000, 5000)}{new Random().Next(1000, 5000)}"
                };

                _context.BankAccountClients.Add(bankAccountClient);
                _context.SaveChanges();

                BankAccAvailable bankAccAvailable = new BankAccAvailable()
                {
                    BankAccountId = bankAccountClient.Id,
                    CreditCardId = idCreditCard.Id,
                    DateCreate = DateTime.Now
                };

                _context.BankAccAvailables.Add(bankAccAvailable);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                Results.BadRequest();
                throw;
            }
        }
    }
}
