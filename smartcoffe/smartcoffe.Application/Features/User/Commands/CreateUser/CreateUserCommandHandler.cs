using MediatR;
using smartcoffe.Application.Features.User.Commands.CreateUser;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.User.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // 1. Mapeo de Command a Entidad de Dominio
        var user = new Domain.Entities.User
        {
            Name = request.Name,
            Phonenumber = request.Phonenumber,
            Email = request.Email,
            // IMPORTANTE: Aquí deberías hashear la contraseña en un escenario real
            Password = request.Password, 
            Rrole = request.Role, // Mapeo a tu propiedad 'Rrole'
            Status = true // Por defecto activo al crear
        };

        // 2. Agregar la entidad al repositorio a través del UnitOfWork
        // Asumo que tu UoW tiene una propiedad 'Users' que es el repositorio
        await _unitOfWork.Users.AddAsync(user);

        // 3. Guardar cambios (Commit de la transacción)
        await _unitOfWork.CompleteAsync();

        // 4. Retornar el ID generado
        return user.Id;
    }
}