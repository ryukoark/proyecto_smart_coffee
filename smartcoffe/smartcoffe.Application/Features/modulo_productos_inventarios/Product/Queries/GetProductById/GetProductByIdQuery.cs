using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Product.DTOs;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Product.Queries.GetProductById
{
    // Este query usa un ID y devuelve el DTO detallado
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
}