namespace smartcoffe.Application.Features.modulo_usuarios.User.DTOs;

public class CreateUserDto
{
    public string Name { get; set; }
    public string? Phonenumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}