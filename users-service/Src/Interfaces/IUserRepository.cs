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
        UserDto CreateUser(CreateUserDto createUserDto);
        /// <summary>
        /// Metodo para obtener los usuarios
        /// </summary>
        /// <returns>Retorna los usuarios</returns>
        List<UserDto> GetUsers();
        /// <summary>
        /// Metodo para obtener un usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <returns>Retorna los datos del usuario</returns>
        UserDto GetUserById(string userId);
        /// <summary>
        /// Metodo para editar el usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <param name="requestEditUserDto">Datos necesarios para editar el usuario</param>
        /// <returns>Retorna el usuario editado</returns>
        UserDto EditUser(string userId, RequestEditUserDto requestEditUserDto);
        /// <summary>
        /// Metodo para eliminar un usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <returns>Retorna el usuario eliminado</returns>
        UserDto DeleteUser(string userId);
        /// <summary>
        /// Metodo para logear a un usuario
        /// </summary>
        /// <param name="requestLoginDto">Datos necesarios para el login</param>
        /// <returns>Retorna un JWT</returns>
        string Login(RequestLoginDto requestLoginDto);
    }
}