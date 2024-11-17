using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SovcomHackAPI.ActionClass.User;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserLockController : ControllerBase
    {
        private readonly SovcomHackContext _SovcomHackContext;
        public UserLockController(SovcomHackContext sovcomHackContext)
        {
            _SovcomHackContext = sovcomHackContext;
        }

        [HttpPut("user/lock/{Login}")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<User>>> LockUser(String Login) 
        {
            var user = await GetUser(Login);

            if (user is not null)
            {
                switch (user.IsActive)
                {
                    case true:
                        user.IsActive= false;
                        break;
                    case false:
                        user.IsActive= true;
                        break;
                }

                await _SovcomHackContext.SaveChangesAsync();

                UserActivationDto _user = new()
                {
                    Login = user.Login,
                    IsActive = user.IsActive.ToString(),
                };

                return Ok(_user);
            }
            return NotFound();
        }

        private async Task<User?> GetUser(string Login) => await _SovcomHackContext.Users.FirstOrDefaultAsync(u => u.Login == Login);
    }
}
