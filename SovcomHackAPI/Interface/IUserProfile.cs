using SovcomHackAPI.ActionClass.User;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.Interface
{
    public interface IUserProfile
    {
        public List<User> GetUserDetail(int id);
    }
}
