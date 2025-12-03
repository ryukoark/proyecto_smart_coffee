using MediatR;
using smartcoffe.Application.Features.modulo_usuarios.User.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_usuarios.User.Queries.GetAllUsersQuery
{
    public class GetAllUsersQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<modulo_usuarios.User.Queries.GetAllUsersQuery.GetAllUsersQuery, IEnumerable<UserDto>>
    {
        public async Task<IEnumerable<UserDto>> Handle(modulo_usuarios.User.Queries.GetAllUsersQuery.GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            // 1. Obtener la lista de entidades desde el repositorio
            // Asumiendo que tu IUnitOfWork tiene un repositorio 'Users' o usas un método genérico
            var usersList = await unitOfWork.Repository<Domain.Entities.User>().GetAllAsync(); 

            // 2. Mapear de Entidad a DTO
            // Si usas AutoMapper: return _mapper.Map<IEnumerable<UserDto>>(usersList);
            // Si es manual:
            var usersDto = usersList.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Phonenumber = u.Phonenumber,
                Email = u.Email,
                Role = u.Rrole, // Nota: Mapeado a tu propiedad 'Rrole'
                Status = u.Status
            });

            return usersDto;
        }
    }
}