namespace smartcoffe.Application.Features.User.DTOs;

public class UserResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Phonenumber { get; set; }
    public string Email { get; set; } = null!;
    public string Rrole { get; set; } = null!;
    public bool Status { get; set; }
    // Los campos de relaciones (PurchaseHistories, Shoppings) generalmente se omiten
    // o se cargan a través de Queries separadas para evitar sobrecarga (Over-fetching).
}