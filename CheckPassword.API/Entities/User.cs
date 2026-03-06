namespace CheckPassword.API.Entities;

public class User
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}

public record RegisterDto(string Nome, string Email, string Senha);
public record LoginDto(string Email, string Senha);
