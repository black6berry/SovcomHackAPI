using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SovcomHackAPI.Interface;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.Controllers
{
    [Route("api/info")]
    [ApiController]
    public class GetUserInfoController : ControllerBase
    {
        private readonly IUserProfile _IUserProfile;
        public GetUserInfoController(IUserProfile IUserProfile)
        {
            _IUserProfile = IUserProfile;
        }

        /// <summary>
        /// Получаем информацию по одному пользователю
        /// </summary>
        /// <returns>Возвращает массив по одному пользователю через логин</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<User>>> Get(int id)
            => await Task.FromResult(_IUserProfile.GetUserDetail(id));
    }
}
