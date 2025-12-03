using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Dtos;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Cafes.Queries.GetCafesByIdQuery
{
    public class GetCafeByIdQuery : IRequest<CafeGetDto>
    {
        public int Id { get; set; }

        public GetCafeByIdQuery(int id)
        {
            Id = id;
        }
    }
}