using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SovcomHackAPI.Interface;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        ICreditCard _ICreditCard;
        public CreditCardController(ICreditCard ICreditCard)
        {
           _ICreditCard = ICreditCard;
        }

        /// <summary>
        /// Получаем информацию по одному пользователю
        /// </summary>
        /// <returns>Возвращает массив по одному пользователю через логин</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CreditCard>>> Get(long id)
            => await Task.FromResult(_ICreditCard.GetCreditMyCard(id));
    }
}
