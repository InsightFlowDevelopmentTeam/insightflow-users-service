namespace users_service.Src.DTOs
{
    /// <summary>
    /// Dto del usuario
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Id del usuario
        /// </summary>     
        public string Id { get; set; } = string.Empty;
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
        /// Rol del usuario
        /// </summary>
        public string Role { get; set; } = string.Empty;
        /// <summary>
        /// Número de telefono del usuario
        /// </summary>
        public int PhoneNumber { get; set; }
    }
}