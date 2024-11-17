namespace SovcomHackAPI.ActionClass.User
{
    public class UserActivationDto
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; } = null!;

        /// <summary>
        /// Статус пользователя
        /// </summary>
        public string IsActive { get; set; } = null!;
    }
}
