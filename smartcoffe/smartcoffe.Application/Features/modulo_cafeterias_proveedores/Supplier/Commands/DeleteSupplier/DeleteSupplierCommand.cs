using MediatR;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.Commands.DeleteSupplier
{
    public record DeleteSupplierCommand(int Id) : IRequest;
}