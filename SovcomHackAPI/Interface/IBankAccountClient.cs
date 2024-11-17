using SovcomHackAPI.ActionClass.User;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.Interface
{
    public interface IBankAccountClient
    {
        public List<BankAccountClient> GetBankAccountClient(long id);
    }
}
