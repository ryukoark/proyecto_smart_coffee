using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_usuarios.User.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        // 1. Obtener entidad del repositorio
        var user = await _unitOfWork.Repository<Domain.Entities.User>().GetByIdAsync(request.Id);

        if (user == null) return false;

        // 2. Actualizar campos
        user.Name = request.Name;
        user.Phonenumber = request.Phonenumber;
        user.Email = request.Email;
        user.Rrole = request.Role;
        user.Status = request.Status;

        // 3. Guardar cambios (Entity Framework trackea los cambios automáticamente)
        // Si tu repo requiere un Update explícito: _unitOfWork.Users.Update(user);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}