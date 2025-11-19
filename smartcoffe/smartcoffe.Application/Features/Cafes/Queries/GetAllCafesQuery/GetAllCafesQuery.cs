using MediatR;
using smartcoffe.Application.Features.Cafes.Dtos;

namespace smartcoffe.Application.Features.Cafes.Queries.GetAllCafesQuery
{
    public class GetAllCafesQuery : IRequest<IEnumerable<CafeListDto>> // ¡Esto es correcto!
    {
    }
}