using users_service.Src.DTOs;
using users_service.Src.Models;

namespace users_service.Src.Mappers
{
    /// <summary>
    /// Clase estatica mapper del usuario
    /// </summary>
    public static class UserMapper
    {
        /// <summary>
        /// Metodo para mapear desde el modelo 'User' al dto 'UserDto'
        /// </summary>
        /// <param name="user">Usuario a mappear</param>
        /// <returns>Retorna el usuario dto</returns>
        public static UserDto ToDtoFromUser(this User user)
        {
            return new UserDto
            {
                Id = user.Id.ToString(),
                FullName = user.FullName,
                Email = user.Email,
                NickName = user.NickName,
                BirthDate = user.BirthDate,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
            };
        }
    }
}