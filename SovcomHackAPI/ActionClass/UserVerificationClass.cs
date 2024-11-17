using Microsoft.AspNetCore.Mvc;
using SovcomHackAPI.Interface;
using SovcomHackAPI.Models;

namespace SovcomHackAPI.ActionClass
{
    public class UserVerificationClass 
    {
        private readonly IVerifyUser _IVerifyUser;
        private readonly SovcomHackContext _SovcomHackContext;

        public UserVerificationClass(IVerifyUser iVerifyUser, SovcomHackContext sovcomHackContext)
        {
            _IVerifyUser = iVerifyUser;
            _SovcomHackContext= sovcomHackContext;
        }
    }
}
