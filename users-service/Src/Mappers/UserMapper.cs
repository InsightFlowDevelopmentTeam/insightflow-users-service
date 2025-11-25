using users_service.Src.DTOs;
using users_service.Src.Models;

namespace users_service.Src.Mappers
{
    public static class UserMapper
    {
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