using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Product.DTOs;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Product.Queries.GetAllProducts
{
    // Este query devuelve una lista de ProductListDto
    public record GetAllProductsQuery() : IRequest<IEnumerable<ProductListDto>>;
}