using MediatR;
using smartcoffe.Application.Features.Product.DTOs;

namespace smartcoffe.Application.Features.Product.Queries.GetProductById
{
    // Este query usa un ID y devuelve el DTO detallado
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
}