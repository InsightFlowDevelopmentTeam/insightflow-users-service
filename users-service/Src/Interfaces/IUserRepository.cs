using users_service.Src.DTOs;

namespace users_service.Src.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<List<UserDto>> GetUsers();
        Task<UserDto> GetUserById(string userId);
        Task<UserDto> EditUser(string userId, RequestEditUserDto requestEditUserDto);
        Task<UserDto> DeleteUser(string userId);
    }
}