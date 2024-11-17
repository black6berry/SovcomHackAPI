namespace SovcomHackAPI.ActionClass.User
{
    public class UserVerifyDto
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; } = null!;

        /// <summary>
        /// Подтверждение аккаунта пользователя
        /// </summary>
        public string Verified { get; set; } = null!;
    }
}
