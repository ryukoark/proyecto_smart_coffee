using MediatR;

namespace smartcoffe.Application.Features.Supplier.Commands.DeleteSupplier
{
    public record DeleteSupplierCommand(int Id) : IRequest;
}