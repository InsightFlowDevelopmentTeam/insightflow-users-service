using System.ComponentModel.DataAnnotations;

namespace users_service.Src.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string Password { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}