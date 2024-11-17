using SovcomHackAPI.ActionClass.User;

namespace SovcomHackAPI.Interface
{
    public interface ICreateUser
    {
        public bool AddAccount(AccountCreate account);
    }
}
