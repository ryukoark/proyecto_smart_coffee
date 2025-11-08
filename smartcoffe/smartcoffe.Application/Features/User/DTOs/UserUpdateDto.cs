namespace smartcoffe.Application.Features.User.DTOs;

public class UserUpdateDto
{
    public int Id { get; set; } // Necesario para identificar qué usuario actualizar.
    public string Name { get; set; } = null!;
    public string? Phonenumber { get; set; }
    // La actualización de Email podría requerir lógica adicional (ej. verificación).
    // string Email { get; set; } = null!; 
    public string Rrole { get; set; } = null!;
    public bool Status { get; set; }
}