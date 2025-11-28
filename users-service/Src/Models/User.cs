using System.ComponentModel.DataAnnotations;

namespace users_service.Src.Models
{
    /// <summary>
    /// Clase de usuario
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Nombre completo del usuario
        /// </summary>
        public string FullName { get; set; } = string.Empty;
        /// <summary>
        /// Correo electrónico del usuario
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Apodo del usuario
        /// </summary>
        public string NickName { get; set; } = string.Empty;
        /// <summary>
        /// Fecha de nacimiento del usuario
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Dirección del usuario
        /// </summary>
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// Número de telefono del usuario
        /// </summary>
        public int PhoneNumber { get; set; }
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// Indicador de usuario eliminado
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}