using Microsoft.AspNetCore.Http.HttpResults;
using users_service.Src.Data;
using users_service.Src.DTOs;
using users_service.Src.Interfaces;
using users_service.Src.Mappers;
using users_service.Src.Models;

namespace users_service.Src.Repositories
{
    /// <summary>
    /// Repositorio de usuario
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Contexto de datos de usuario
        /// </summary>
        private UserDataContext _context;

        public UserRepository(UserDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo para crear un usuario
        /// </summary>
        /// <param name="createUserDto">Datos necesarios para la creacion del usuario</param>
        /// <returns>Retorna el usuario creado</returns>
        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            // Se obtienen los usuarios
            var users = _context.UsersData;

            // Validacion: Nombre de usuario ya registrado.
            if (users.Any(u => u.FullName == createUserDto.FullName) == true)
            {
                throw new Exception("Este nombre ya esta registrado");
            }

            // Validacion: Correo electronico del usuario ya registrado.
            if (users.Any(u => u.FullName == createUserDto.FullName) == true)
            {
                throw new Exception("Este correo electrónico ya esta registrado");
            }

            // Validacion: Apodo de usuario ya registrado.
            if (users.Any(u => u.NickName == createUserDto.NickName) == true)
            {
                throw new Exception("Este apodo ya esta registrado");
            }

            // Validacion: Fecha de nacimiento superior a la fecha actual.
            if (createUserDto.BirthDate > DateTime.UtcNow)
            {
                throw new Exception("La fecha de nacimiento es superior a la fecha actual");
            }

            // Validacion: Numero de telefono superior a la fecha actual.
            if (users.Any(u => u.PhoneNumber == createUserDto.PhoneNumber) == true)
            {
                throw new Exception("Este número de teléfono ya esta registrado");
            }

            // Se crea el nuevo usuario
            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = createUserDto.FullName,
                Email = createUserDto.Email,
                NickName = createUserDto.NickName,
                BirthDate = createUserDto.BirthDate,
                Address = createUserDto.Address,
                PhoneNumber = createUserDto.PhoneNumber,
                Password = createUserDto.Password,
                IsDeleted = false
            };

            // Se guarda el usuario
            _context.UsersData.Add(user);
            
            // Retorna el usuario dto
            return user.ToDtoFromUser();
        }

        /// <summary>
        /// Metodo para obtener todos los usuarios
        /// </summary>
        /// <returns>Retorna todos los usuarios registrados activos</returns>
        public async Task<List<UserDto>> GetUsersAsync()
        {
            // Se obtienen los usuarios dtos activos
            var users = _context.UsersData.Where(u => u.IsDeleted == false).Select(u => u.ToDtoFromUser()).ToList();

            // Se retorna la lista de usuarios
            return users;
        }

        /// <summary>
        /// Metodo para obtener un usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <returns>Retorna los datos del usuario</returns>
        public async Task<UserDto> GetUserByIdAsync(string userId)
        {
            // Se obtiene los datos del usuario
            var user = _context.UsersData.Find(u => u.Id.ToString() == userId & u.IsDeleted == false);
            
            // Validacion: El usuario no existe
            if(user == null) throw new Exception("Este usuario no existe");
            
            // Retorna el usuario dto
            return user.ToDtoFromUser();
        }

        /// <summary>
        /// Metodo para editar el usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <param name="requestEditUserDto">Datos necesarios para editar el usuario</param>
        /// <returns>Retorna el usuario editado</returns>
        public async Task<UserDto> EditUserAsync(string userId, RequestEditUserDto requestEditUserDto)
        {
            // Se obtiene el usuario a editar
            var user = _context.UsersData.Find(u => u.Id.ToString() == userId & u.IsDeleted == false);
            
            // Validacion: El usuario no existe
            if(user == null) throw new Exception("Este usuario no existe");

            // Se actualiza el usuario
            user.FullName = requestEditUserDto.FullName;
            user.NickName = requestEditUserDto.NickName;

            // Se retorna el usuario dto actualizado
            return user.ToDtoFromUser();
        }
        
        /// <summary>
        /// Metodo para eliminar un usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <returns>Retorna el usuario eliminado</returns>
        public async Task<UserDto> DeleteUserAsync(string userId)
        {
            // Se obtienen el usuario a eliminar
            var user = _context.UsersData.Find(u => u.Id.ToString() == userId & u.IsDeleted == false);
            
            // Validacion: El usuario no existe
            if(user == null) throw new Exception("Este usuario no existe");
            
            // Se realiza el soft delete del usuario
            user.IsDeleted = true;
            
            // Se retorna el usuario eliminado
            return user.ToDtoFromUser();        
        }
    }
}