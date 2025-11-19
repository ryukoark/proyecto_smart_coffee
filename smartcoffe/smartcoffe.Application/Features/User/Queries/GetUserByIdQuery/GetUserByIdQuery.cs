using MediatR;
using smartcoffe.Application.Features.User.DTOs;

namespace smartcoffe.Application.Features.User.Queries.GetUserByIdQuery
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