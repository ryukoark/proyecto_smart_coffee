using MediatR;
using smartcoffe.Application.Features.modulo_usuarios.User.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_usuarios.User.Queries.GetUserByIdQuery
{
    public class GetUserByIdQueryHandler : IRequestHandler<modulo_usuarios.User.Queries.GetUserByIdQuery.GetUserByIdQuery, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Handle(modulo_usuarios.User.Queries.GetUserByIdQuery.GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            // 1. Buscar en la base de datos
            var user = await _unitOfWork.Repository<Domain.Entities.User>().GetByIdAsync(request.Id);

            // 2. Validar existencia
            if (user == null)
            {
                // Puedes retornar null o lanzar una excepción personalizada tipo NotFoundException
                return null; 
            }

            // 3. Mapear a DTO
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Phonenumber = user.Phonenumber,
                Email = user.Email,
                Role = user.Rrole,
                Status = user.Status
            };
        }
    }
}