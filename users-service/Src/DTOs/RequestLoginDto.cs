namespace users_service.Src.DTOs
{
    public class RequestLoginDto
    {
        /// <summary>
        /// Correo electronico del usuario
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}