using users_service.Src.Models;

namespace users_service.Src.Data
{
    public class UserDataContext
    {
        public List<User> UsersData { get; set; } = new List<User>();
    }
}