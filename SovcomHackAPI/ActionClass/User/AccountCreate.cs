namespace SovcomHackAPI.ActionClass.User
{
    public class AccountCreate
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronomic { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
