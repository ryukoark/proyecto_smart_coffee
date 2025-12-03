using Microsoft.AspNetCore.Mvc;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Domain.Entities;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            var users = await _uow.Repository<User>().FindAsync(u => u.Email == request.Email && u.Password == request.Password && u.Status);
            var user = users.FirstOrDefault();
            if (user is null)
                return Unauthorized(new { message = "Usuario no existe o credenciales no válidas" });

            var token = _authService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}