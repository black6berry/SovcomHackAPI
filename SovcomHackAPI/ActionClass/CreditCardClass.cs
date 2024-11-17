using SovcomHackAPI.Interface;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.ActionClass
{
    public class CreditCardClass : ICreditCard
    {
        SovcomHackContext _context;
        public CreditCardClass(SovcomHackContext context)
        {
            _context = context;
        }
        public List<CreditCard> GetCreditMyCard(long id)
        {
            try
            {
                var data = _context.CreditCards.Where(x => x.Id == id).ToList();
                return (List<CreditCard>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }

        }
    }
}
