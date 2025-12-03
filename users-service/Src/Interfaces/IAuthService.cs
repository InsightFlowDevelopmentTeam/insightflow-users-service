using users_service.Src.DTOs;

namespace users_service.Src.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Metodo para logear a un usuario
        /// </summary>
        /// <param name="requestLoginDto">Datos necesarios para el login</param>
        /// <returns>Retorna un JWT</returns>
        string Login(RequestLoginDto requestLoginDto);
    }
}