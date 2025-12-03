using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Dtos;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Queries.GetAllCafesQuery
{
    public class GetAllCafesQuery : IRequest<IEnumerable<CafeListDto>> // ¡Esto es correcto!
    {
    }
}