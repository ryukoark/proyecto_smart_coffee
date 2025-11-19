using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(request.Id);
        if (user == null) return false;

        // Opción: Borrado lógico cambiando el estado
        user.Status = false;
            
        // Opción: Borrado físico si lo prefieres
        // _unitOfWork.Users.Remove(user);

        await _unitOfWork.CompleteAsync();
        return true;
    }
}