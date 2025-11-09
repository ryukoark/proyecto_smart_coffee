using MediatR;
using smartcoffe.Application.Features.Product.DTOs;

namespace smartcoffe.Application.Features.Product.Commands.CreateProduct
{
    // Este comando envuelve el DTO de creación
    // Devuelve 'Unit' (el equivalente de MediatR a 'void') porque no necesitamos devolver datos.
    public record CreateProductCommand(ProductCreateDto Product) : IRequest;
}