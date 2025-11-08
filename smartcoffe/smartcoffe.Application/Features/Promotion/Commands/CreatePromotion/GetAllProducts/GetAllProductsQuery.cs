using MediatR;
using smartcoffe.Application.Features.Product.DTOs;

namespace smartcoffe.Application.Features.Product.Queries.GetAllProducts
{
    // Este query devuelve una lista de ProductListDto
    public record GetAllProductsQuery() : IRequest<IEnumerable<ProductListDto>>;
}