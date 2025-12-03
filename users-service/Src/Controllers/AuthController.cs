using Microsoft.AspNetCore.Mvc;
using users_service.Src.DTOs;
using users_service.Src.Exceptions;
using users_service.Src.Interfaces;

namespace users_service.Src.Controllers
{
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Repositorio de auth
        /// </summary>
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Endpoint para logear a un usuario
        /// </summary>
        /// <param name="requestLoginDto">Datos necesario para logearse</param>
        /// <returns>Retorna un JWT</returns>
        [HttpPost("/login")]
        public IActionResult Login([FromBody] RequestLoginDto requestLoginDto)
        {
            // Validacion: Modelo invalido
            if(!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var token = _authService.Login(requestLoginDto);
                return Ok(token);    
            }
            catch(BadRequestException ex)
            {
                return BadRequest( new { message = ex.Message});
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message});
            }
        }
    }
}