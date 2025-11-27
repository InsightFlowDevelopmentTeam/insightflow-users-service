using System.ComponentModel.DataAnnotations;

namespace users_service.Src.DTOs
{
    /// <summary>
    /// Dto de petición para editar el usuario
    /// </summary>
    public class RequestEditUserDto
    {
        /// <summary>
        /// Nombre completo del usuario
        /// </summary>
        [Required]
        [MinLength(5, ErrorMessage = "El nombre completo debe tener mas de 5 caracteres")]
        public string FullName { get; set; } = string.Empty;
        /// <summary>
        /// Apodo del usuario
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "El apodo debe tener mas de 1 caracter")]
        public string NickName { get; set; } = string.Empty;
    }
}