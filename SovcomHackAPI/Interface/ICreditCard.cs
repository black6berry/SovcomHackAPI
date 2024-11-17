using SovcomHackAPI.Models;

namespace SovcomHackAPI.Interface
{
    public interface ICreditCard
    {
        public List<CreditCard> GetCreditMyCard(long id);
    }
}
