namespace smartcoffe.Application.Features.User.DTOs;

// UserCreateDto.cs
public class UserCreateDto
{
    public string Name { get; set; } = null!;
    public string? Phonenumber { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!; // ¡Importante! Asegúrate de hashear la contraseña en el handler.
    public string Rrole { get; set; } = "Cliente"; // Puedes establecer un valor predeterminado si aplica.
}