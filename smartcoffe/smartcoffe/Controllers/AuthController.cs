using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Domain.Entities;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] // Importante: Permite el acceso sin token JWT
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _uow;

        public AuthController(IAuthService authService, IUnitOfWork uow)
        {
            _authService = authService;
            _uow = uow;
        }

        public class TokenRequest
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> Generate([FromBody] TokenRequest request)
        {
            if (request is null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Email and Password are required");

            // 1. Buscar el usuario por email, contraseña y estado activo
            var users = await _uow.Repository<User>().FindAsync(u => u.Email == request.Email && u.Password == request.Password && u.Status);
            var user = users.FirstOrDefault();
            
            if (user is null)
                return Unauthorized(new { message = "Usuario no existe o credenciales no válidas" });
            
            // 2. Generar el token con el ROL REAL del usuario (propiedad Rrole de la entidad User)
            // Asegúrate que tu AuthService lee el campo Rrole del objeto User
            var token = _authService.GenerateToken(user);
            
            return Ok(new { token, role = user.Rrole }); // Opcional: devolver el rol para facilitar las pruebas
        }
    }
}