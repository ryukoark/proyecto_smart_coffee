using MediatR;
using smartcoffe.Application.Features.User.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.User.Queries.GetAllUsersQuery
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            // 1. Obtener la lista de entidades desde el repositorio
            // Asumiendo que tu IUnitOfWork tiene un repositorio 'Users' o usas un método genérico
            var usersList = await _unitOfWork.Users.GetAllAsync(); 

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