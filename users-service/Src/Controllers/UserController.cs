using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using users_service.Src.DTOs;
using users_service.Src.Exceptions;
using users_service.Src.Interfaces;

namespace users_service.Src.Controllers
{
    /// <summary>
    /// Controller del usuario
    /// </summary>
    [ApiController]
    [Route("user/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Repositorio del usuario
        /// </summary>
        private readonly IUserRepository _userRepository;
        
        /// <summary>
        /// Instancia del user controller
        /// </summary>
        /// <param name="userRepository">Repositorio del usuario</param>
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Endpoint para crear el usuario
        /// </summary>
        /// <param name="createUserDto">Datos necesarios para crear el usuario</param>
        /// <returns>Retorna usuario creado</returns>
        [HttpPost("/createUser")]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            // Validacion: Modelo invalido
            if(!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var user = _userRepository.CreateUser(createUserDto);
                return Ok(user);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (ConflictException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message});
            }
        }
        
        /// <summary>
        /// Endpoint para obtener los usuarios
        /// </summary>
        /// <returns>Retorna los usuarios activos</returns>
        [Authorize(Roles = "ADMIN")]
        [HttpGet("/getUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userRepository.GetUsers();
                return Ok(users);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message});
            }
        }

        /// <summary>
        /// Endpoint para obtener un usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <returns>Retorna el usuario</returns>
        [Authorize(Roles = "USER, ADMIN")]
        [HttpGet("/getUserById/{userId}")]
        public IActionResult GetUserById([FromRoute] string userId)
        {
            try
            {
                var user = _userRepository.GetUserById(userId);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message});
            }
        }

        /// <summary>
        /// Endpoint para editar el usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <param name="requestEditUserDto">Datos necesarios para editar el usuario</param>
        /// <returns>Retorna el usuario editado</returns>
        [Authorize(Roles = "USER, ADMIN")]
        [HttpPut("/editUser/{userId}")]
        public IActionResult EditUser([FromRoute] string userId, [FromBody] RequestEditUserDto requestEditUserDto)
        {
            // Validacion: Modelo invalido
            if(!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var user = _userRepository.EditUser(userId, requestEditUserDto);
                return Ok(user);
            }
            catch(ConflictException ex)
            {
                return Conflict( new { message = ex.Message});
            }
            catch(NotFoundException ex)
            {
                return NotFound( new { mesage = ex.Message});
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message});
            }
        }

        /// <summary>
        /// Endpoint para eliminar usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <returns>Retorna usuario eliminado</returns>
        [Authorize(Roles = "ADMIN")]
        [HttpDelete("/deleteUser/{userId}")]
        public IActionResult DeleteUser([FromRoute] string userId)
        {
            try
            {
                var user = _userRepository.DeleteUser(userId);
                return Ok(user);
            }
            catch(NotFoundException ex)
            {
                return NotFound( new { message = ex.Message});
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message});
            }
        }
    }
}