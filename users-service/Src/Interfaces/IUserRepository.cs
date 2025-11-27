using users_service.Src.DTOs;

namespace users_service.Src.Interfaces
{
    /// <summary>
    /// Interface del repositorio de usuario
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Metodo para crear el usuario
        /// </summary>
        /// <param name="createUserDto">Datos necesarios para crear el usuario</param>
        /// <returns>Retorna el usuario creado</returns>
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        /// <summary>
        /// Metodo para obtener los usuarios
        /// </summary>
        /// <returns>Retorna los usuarios</returns>
        Task<List<UserDto>> GetUsersAsync();
        /// <summary>
        /// Metodo para obtener un usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <returns>Retorna los datos del usuario</returns>
        Task<UserDto> GetUserByIdAsync(string userId);
        /// <summary>
        /// Metodo para editar el usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <param name="requestEditUserDto">Datos necesarios para editar el usuario</param>
        /// <returns>Retorna el usuario editado</returns>
        Task<UserDto> EditUserAsync(string userId, RequestEditUserDto requestEditUserDto);
        /// <summary>
        /// Metodo para eliminar un usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <returns>Retorna el usuario eliminado</returns>
        Task<UserDto> DeleteUserAsync(string userId);
    }
}