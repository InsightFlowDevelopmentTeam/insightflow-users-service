using users_service.Src.Models;

namespace users_service.Src.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Metodo para crear el token
        /// </summary>
        /// <param name="user">Usuario</param>
        /// <returns>Retorna el JWT</returns>
        string CreateToken(User user);
    }
}