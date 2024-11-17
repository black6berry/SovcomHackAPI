using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SovcomHackAPI.Interface;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountClientController : ControllerBase
    {
        IBankAccountClient _IBankAccountClient;
        public BankAccountClientController(IBankAccountClient iBankAccountClient)
        {
            _IBankAccountClient = iBankAccountClient;
        }


        /// <summary>
        /// Получаем информацию по одному пользователю
        /// </summary>
        /// <returns>Возвращает массив по одному пользователю через логин</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BankAccountClient>>> Get(long id)
            => await Task.FromResult(_IBankAccountClient.GetBankAccountClient(id));


    }
}
