using MediatR;
using smartcoffe.Application.Features.modulo_usuarios.User.DTOs;

namespace smartcoffe.Application.Features.modulo_usuarios.User.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}