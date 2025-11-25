using Microsoft.AspNetCore.Http.HttpResults;
using users_service.Src.Data;
using users_service.Src.DTOs;
using users_service.Src.Interfaces;
using users_service.Src.Mappers;
using users_service.Src.Models;

namespace users_service.Src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserDataContext _context; 
        public UserRepository(UserDataContext context)
        {
            _context = context;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
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

            _context.UsersData.Add(user);
            
            return user.ToDtoFromUser();
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var users = _context.UsersData.Select(u => u.ToDtoFromUser()).ToList();
            return users;
        }

        public async Task<UserDto> GetUserById(string userId)
        {
            var user = _context.UsersData.Find(u => u.Id.ToString() == userId);

            if(user == null)
            {
                throw new Exception("Este usuario no existe");
            }
            return user.ToDtoFromUser();
        }

        public async Task<UserDto> EditUser(string userId, RequestEditUserDto requestEditUserDto)
        {
            var user = _context.UsersData.Find(u => u.Id.ToString() == userId);
            
            if(user == null)
            {
                throw new Exception("Este usuario no existe");
            }

            user.FullName = requestEditUserDto.FullName;
            user.NickName = requestEditUserDto.NickName;

            return user.ToDtoFromUser();
        }

        public async Task<UserDto> DeleteUser(string userId)
        {
            var user = _context.UsersData.Find(u => u.Id.ToString() == userId);
            
            if(user == null)
            {
                throw new Exception("Este usuario no existe");
            }

            user.IsDeleted = true;
            
            return user.ToDtoFromUser();        
        }
    }
}