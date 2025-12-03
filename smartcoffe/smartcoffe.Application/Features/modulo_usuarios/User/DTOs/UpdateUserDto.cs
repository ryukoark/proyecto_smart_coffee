namespace smartcoffe.Application.Features.modulo_usuarios.User.DTOs;

public class UpdateUserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Phonenumber { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public bool Status { get; set; }
    // Opcional: Password si permites cambiarla aquí, o haz un comando separado.
}