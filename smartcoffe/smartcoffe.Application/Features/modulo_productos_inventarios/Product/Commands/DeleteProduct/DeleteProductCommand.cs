using MediatR;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Product.Commands.DeleteProduct
{
    public record DeleteProductCommand(int Id) : IRequest;
}