using MediatR;
using smartcoffe.Application.Features.Product.DTOs;

namespace smartcoffe.Application.Features.Product.Commands.UpdateProduct
{
    // Pasamos tanto el Id (de la ruta) como el DTO (del cuerpo)
    public record UpdateProductCommand(int Id, ProductUpdateDto Product) : IRequest;
}