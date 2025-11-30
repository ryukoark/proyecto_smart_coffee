using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Repository<Domain.Entities.User>().GetByIdAsync(request.Id);
        if (user == null) return false;

        // Opción: Borrado lógico cambiando el estado
        user.Status = false;
            
        // Opción: Borrado físico si lo prefieres
        // _unitOfWork.Users.Remove(user);

        await unitOfWork.CompleteAsync();
        return true;
    }
}