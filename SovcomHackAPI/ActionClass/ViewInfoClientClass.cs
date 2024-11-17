using SovcomHackAPI.Interface;
using SovcomHackAPI.Models;
using System.Numerics;

namespace SovcomHackAPI.ActionClass
{
    public class ViewInfoClientClass : IUserProfile
    {
        private readonly SovcomHackContext _context;

        public ViewInfoClientClass(SovcomHackContext context) => _context = context;
        public List<Models.User> GetUserDetail(int id)
        {
            try
            {
                var data = _context.Users.Select(
                   x => new Models.User()
                   {
                       Name = x.Name,
                       Surname = x.Surname,
                       Patronomic = x.Patronomic,
                       Phone = x.Phone,
                       LastConnect = x.LastConnect,
                       Role = x.Role,
                       Verified = x.Verified,
                       IsActive = x.IsActive,
                       Login = x.Login,
                       Id = x.Id
                   }
                   ).Where(u => u.Id == id).ToList();
                return (List<Models.User>)data;


            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }
    }
}
