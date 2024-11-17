using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SovcomHackAPI.ActionClass.User;
using SovcomHackAPI.Interface;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserVerificationController : ControllerBase
    {
        private readonly SovcomHackContext _SovcomHackContext;
        public UserVerificationController(SovcomHackContext sovcomHackContext)
        {
            _SovcomHackContext = sovcomHackContext;
        }

        [HttpPut("user/verify/{Login}")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<UserVerifyDto>>> VerifyUser(string Login)
        {

            var user = await GetUser(Login);

            if (user is not null)
            {
                user.Verified = true;

                await _SovcomHackContext.SaveChangesAsync();

                UserVerifyDto _user = new()
                {
                    Login = user.Login,
                    Verified = user.Verified.ToString()
                };

                return Ok(_user);
            }

            return NotFound();
        }

        private async Task<User?> GetUser(string Login) => await _SovcomHackContext.Users.FirstOrDefaultAsync(u => u.Login == Login);
    }
}