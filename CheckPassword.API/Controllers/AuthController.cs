using CheckPassword.API.Data;
using CheckPassword.API.Entities;
using CheckPassword.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CheckPassword.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context) => _context = context;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            // Criptografando a senha antes de salvar
            var user = new User
            {
                Nome = dto.Nome,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("Usuário criado com sucesso!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, user.PasswordHash))
                return Unauthorized("E-mail ou senha inválidos.");

            var token = TokenService.GenerateToken(user);
            return Ok(new { token });
        }

        [HttpGet("me")]
        [Authorize] // Este atributo protege a rota
        public IActionResult GetMe()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var nome = User.FindFirst(ClaimTypes.Name)?.Value;
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(new { id, nome, email });
        }
    }
}