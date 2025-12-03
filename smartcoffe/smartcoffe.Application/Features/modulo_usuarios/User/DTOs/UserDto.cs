namespace smartcoffe.Application.Features.modulo_usuarios.User.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Phonenumber { get; set; }
    public string Email { get; set; }
    public string Role { get; set; } // Mapeado de 'Rrole'
    public bool Status { get; set; }
}