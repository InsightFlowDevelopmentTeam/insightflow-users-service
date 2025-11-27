using Microsoft.AspNetCore.Mvc;
using users_service.Src.DTOs;
using users_service.Src.Interfaces;

namespace users_service.Src.Controllers
{
    /// <summary>
    /// Controller del usuario
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            // Validacion: Modelo invalido
            if(!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var user = await _userRepository.CreateUserAsync(createUserDto);
                return Ok(user);
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
        [HttpGet("/getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetUsersAsync();
                return Ok(users);
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
        [HttpGet("/getUserById/{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] string userId)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId);
                return Ok(user);
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
        [HttpPut("/editUser/{userId}")]
        public async Task<IActionResult> EditUser([FromRoute] string userId, [FromBody] RequestEditUserDto requestEditUserDto)
        {
            // Validacion: Modelo invalido
            if(!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var user = await _userRepository.EditUserAsync(userId, requestEditUserDto);
                return Ok(user);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message});
            }
        }

        /// <summary>
        /// Endpoint para eliminar un usuario
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <returns>Retorna el usuario eliminado</returns>
        [HttpDelete("/deleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string userId)
        {
            try
            {
                var user = await _userRepository.DeleteUserAsync(userId);
                return Ok(user);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message});
            }
        }
    }
}