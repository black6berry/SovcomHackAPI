using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SovcomHackAPI.ActionClass.User;
using SovcomHackAPI.Interface;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.Controllers
{
    [Route("api/create-profile")]
    [ApiController]
    public class CreateUserController : ControllerBase
    {
        private readonly ICreateUser _ICreateUser;
        public CreateUserController(ICreateUser createUser)
        {
            _ICreateUser = createUser;
        }

        [HttpPost("add")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Post(AccountCreate account)
        {
            if (!_ICreateUser.AddAccount(account))
            {
                await Request.ReadFormAsync();
                return NotFound();
            }
            return Ok();
        }
    }
}
