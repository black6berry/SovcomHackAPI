using SovcomHackAPI.Interface;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.ActionClass
{
    public class BankAccAvailableClass : IBankAvailable
    {
        private readonly SovcomHackContext _context;
        public BankAccAvailableClass(SovcomHackContext context) => _context = context;
      
        public List<BankAccAvailable> GetBankAccountInfo(long id)
        {
            try
            {
                var data = _context.BankAccAvailables.Where(x => x.BankAccountId == id).ToList();
                return (List<BankAccAvailable>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }

        }
    }
}
