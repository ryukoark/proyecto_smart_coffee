using MediatR;
using smartcoffe.Application.Features.Cafes.Dtos;

namespace smartcoffe.Application.Features.Cafes.Queries.GetCafesByIdQuery
{
    public class GetCafeByIdQuery : IRequest<CafeGetDto>
    {
        public int Id { get; set; }

        public GetCafeByIdQuery(int id)   // ✔ CONSTRUCTOR NECESARIO
        {
            Id = id;
        }
    }
}