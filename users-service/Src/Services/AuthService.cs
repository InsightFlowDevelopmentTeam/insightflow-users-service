using users_service.Src.Data;
using users_service.Src.DTOs;
using users_service.Src.Exceptions;
using users_service.Src.Interfaces;

namespace users_service.Src.Services
{
    /// <summary>
    /// Servicio de Autenticacion
    /// </summary>
    public class AuthService : IAuthService
    {
        /// <summary>
        /// Contexto de datos de usuario
        /// </summary>
        private UserDataContext _context;
        /// <summary>
        /// Repositorio del token
        /// </summary>
        private ITokenService _tokenService;
        public AuthService(UserDataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Metodo para logearse
        /// </summary>
        /// <param name="requestLoginDto">Datos necesarios para logearse</param>
        /// <returns>Retornar jwt</returns>
        public string Login(RequestLoginDto requestLoginDto)
        {
            // Buscar al usuario
            var user = _context.UsersData.Find(u => u.Email == requestLoginDto.Email & u.IsDeleted == false);
            
            // Validacion: Credenciales invalidas
            if(user == null) throw new BadRequestException("Credenciales invalidas");
            if(user.Password != requestLoginDto.Password) throw new BadRequestException("Credenciales invalidas");

            // Obtener jwt
            var jwt = _tokenService.CreateToken(user);

            return jwt;
        }
    }
}