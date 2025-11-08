using MediatR;
using smartcoffe.Application.Features.Product.DTOs;

namespace smartcoffe.Application.Features.Product.Queries.GetByIdProduct
{
    // Este query usa un ID y devuelve el DTO detallado
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
}