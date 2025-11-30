using Microsoft.AspNetCore.Mvc;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Domain.Entities;

namespace smartcoffe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IAuthService _authService;

        public TokenController(IAuthService authService)
        {
            _authService = authService;
        }

        public class TokenRequest
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        [HttpPost("generate")]
        public IActionResult Generate([FromBody] TokenRequest request)
        {
            if (request is null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Email and Password are required");

            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                Status = true
            };

            var token = _authService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
