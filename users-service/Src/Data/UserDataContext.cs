using users_service.Src.Models;

namespace users_service.Src.Data
{
    /// <summary>
    /// Clase de datos del usuario
    /// </summary>
    public class UserDataContext
    {
        /// <summary>
        /// Lista de usuarios
        /// </summary>
        public List<User> UsersData { get; set; } = new List<User>();
    }
}