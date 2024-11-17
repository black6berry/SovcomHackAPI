using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SovcomHackAPI.ActionClass.User;
using SovcomHackAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SovcomHackAPI.Controllers
{
    [Route("api/sign-in")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly SovcomHackContext _context;
        public TokenController(IConfiguration config, SovcomHackContext context)
        {
            _configuration = config;
            _context = context;
        }

        /// <summary>
        /// Генерация уникального токена пользователя
        /// </summary>
        /// <param name="_userData">Принимает логин и пароль пользователя</param>
        /// <returns>Возвращает Bearer-токен и статус</returns>
        [HttpPost]
        public async Task<IActionResult> SignIn(UserGetToken _userData)
        {

            if (_userData.Password != null && _userData.Login != null)
            {
                var user = await GetUser(_userData.Login, _userData.Password);

                if (user != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Login", user.Login),
                        new Claim("Name", user.Name),
                        new Claim("Surname", user.Surname),
                        new Claim("Patronomic", user.Patronomic),
                        new Claim("Phone", user.Phone),
                        new Claim("LastConnect", user.LastConnect.ToString()),
                        new Claim("Verified", user.Verified.ToString()),
                        new Claim("IsActive", user.IsActive.ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddDays(10),
                        signingCredentials: signIn);
                    string tokenUser = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(
                            new { 
                                    idClient = user.Id,
                                    token = tokenUser
                            }
                        );
                }
                else
                {
                    return BadRequest("Данные неверны. Повторите авторизацию.");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Получение данных для генерации токена
        /// </summary>
        /// <param name="login">Введите логин пользователя</param>
        /// <param name="password">Введите пароль пользователя</param>
        /// <returns>Возвращает коллекцию по пользователю</returns>
        private async Task<User> GetUser(string login, string password) => await _context.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);

    }
}
