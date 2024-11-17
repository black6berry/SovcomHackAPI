using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using SovcomHackAPI.Interface;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.ActionClass
{
    public class BankAccountClientClass : IBankAccountClient
    {
        private readonly SovcomHackContext _context;
        public BankAccountClientClass(SovcomHackContext context) => _context = context;
        public List<BankAccountClient> GetBankAccountClient(long id)
        {
            try
            {


                var data = _context.BankAccountClients.Where(x => x.UserId == id).ToList();
          



                return (List<BankAccountClient>)data;


            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }
    }
}
