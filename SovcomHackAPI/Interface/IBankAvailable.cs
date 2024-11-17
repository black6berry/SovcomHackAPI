using SovcomHackAPI.Models;

namespace SovcomHackAPI.Interface
{
    public interface IBankAvailable
    {
        public List<BankAccAvailable> GetBankAccountInfo(long id);
    }
}
