using GRProntAPP.Models;
using GRProntAPP.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GRProntAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var token = await _authService.LoginAsync(model.Username, model.Password);
            if (token == null)
                return Unauthorized("Credenciais inválidas");

            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var user = new UserProfile
            {
                UserName = model.Username,
                Email = model.Email,
                FullName = model.FullName,
                Role = "User",
                IsActive = true,
                EmailConfirmed = true
            };

            var result = await _authService.RegisterAsync(user, model.Password);
            if (!result)
                return BadRequest("Erro ao registrar usuário");

            return Ok("Usuário registrado com sucesso");
        }
    }

    public class LoginDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public class RegisterDto
    {
        public required string Username { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
