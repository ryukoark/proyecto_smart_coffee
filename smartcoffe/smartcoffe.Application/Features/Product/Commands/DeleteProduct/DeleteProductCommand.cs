using MediatR;

namespace smartcoffe.Application.Features.Product.Commands.DeleteProduct
{
    public record DeleteProductCommand(int Id) : IRequest;
}