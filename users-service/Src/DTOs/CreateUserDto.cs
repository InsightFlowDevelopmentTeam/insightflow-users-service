using System.ComponentModel.DataAnnotations;

namespace users_service.Src.DTOs
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "El nombre completo debe tener mas de 5 caracteres")]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@insightflow.cl$", 
            ErrorMessage = "El correo debe pertenecer al dominio @insightflow.cl.")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "El apodo debe tener mas de 1 caracter")]
        public string NickName { get; set; } = string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "El dirección debe tener mas de 5 caracteres")]
        public string Address { get; set; } = string.Empty;
        [Required]
        [Range(10000000, 99999999, ErrorMessage = "El numero de telefono debe tener 8 digitos")]
        public int PhoneNumber { get; set; }
        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{8,}$", 
            ErrorMessage = "La contraseña debe tener al menos 8 caracteres, incluir mayúscula, minúscula, número y un carácter especial.")]
        public string Password { get; set; } = string.Empty;
    }
}