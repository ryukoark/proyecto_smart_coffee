using MediatR;
using smartcoffe.Application.Features.User.DTOs;

// Ajusta según dónde guardaste el UserDto

namespace smartcoffe.Application.Features.User.Queries.GetAllUsersQuery
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
        // No se necesitan parámetros para obtener todos
    }
}