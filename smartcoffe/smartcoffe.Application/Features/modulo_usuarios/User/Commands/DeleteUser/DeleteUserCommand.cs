using MediatR;

namespace smartcoffe.Application.Features.modulo_usuarios.User.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<bool>
{
    public int Id { get; set; }
    public DeleteUserCommand(int id) { Id = id; }
}