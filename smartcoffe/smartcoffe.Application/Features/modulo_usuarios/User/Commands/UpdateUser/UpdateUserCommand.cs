using MediatR;

namespace smartcoffe.Application.Features.modulo_usuarios.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Phonenumber { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public bool Status { get; set; }
}