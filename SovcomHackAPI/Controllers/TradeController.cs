using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SovcomHackAPI.ActionClass.User;
using SovcomHackAPI.Interface;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private SovcomHackContext _context;
        public TradeController(SovcomHackContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> TradeProcess(TradeClient tradeClient)
        {
            if (tradeClient is not null)
            {
                var OurDataMoneyFrom = _context.BankAccountClients.FirstOrDefault(x => x.Number == tradeClient.ClientFrom); //500
                var OurDataMoneyTo = _context.BankAccountClients.FirstOrDefault(x => x.Number == tradeClient.ClientTo); //8000

                if (OurDataMoneyFrom.ValueMoney > 0)
                {


                    decimal updateMoneyFrom = OurDataMoneyFrom.ValueMoney - tradeClient.ValueMoney; //8000 - 100
                    decimal updateMoneyTo = OurDataMoneyTo.ValueMoney + tradeClient.ValueMoney; //


                    IEnumerable<BankAccountClient> customersFrom = _context.BankAccountClients
                   .Where(c => c.Number == tradeClient.ClientFrom)
                   .AsEnumerable()
                   .Select(c =>
                   {
                       c.ValueMoney = updateMoneyFrom;
                       c.CheckMoneyDataId = OurDataMoneyFrom.CheckMoneyDataId;
                       c.Number = tradeClient.ClientFrom;
                       return c;
                   });

                    foreach (BankAccountClient customerFrom in customersFrom)
                    {
                        _context.Entry(customerFrom).State = EntityState.Modified;
                    }
                    _context.SaveChanges();


                    IEnumerable<BankAccountClient> customersTo = _context.BankAccountClients
                   .Where(c => c.Number == tradeClient.ClientTo)
                   .AsEnumerable()
                   .Select(c =>
                   {
                       c.ValueMoney = updateMoneyTo;
                       c.CheckMoneyDataId = OurDataMoneyTo.CheckMoneyDataId;
                       c.Number = tradeClient.ClientTo;
                       return c;
                   });

                    foreach (BankAccountClient customerTo in customersTo)
                    {
                        _context.Entry(customerTo).State = EntityState.Modified;
                    }

                    _context.SaveChanges();

                    return Ok();
                }
                else {
                    return BadRequest("Пополните баланс");
                }
            }
            return BadRequest();
        }
    }
}
