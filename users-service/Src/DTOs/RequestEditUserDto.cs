using System.ComponentModel.DataAnnotations;

namespace users_service.Src.DTOs
{
    public class RequestEditUserDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "El nombre completo debe tener mas de 5 caracteres")]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "El apodo debe tener mas de 1 caracter")]
        public string NickName { get; set; } = string.Empty;
    }
}