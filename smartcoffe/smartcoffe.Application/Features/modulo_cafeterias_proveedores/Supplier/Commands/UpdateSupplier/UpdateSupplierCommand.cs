using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.DTOs;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.Commands.UpdateSupplier
{
    public record UpdateSupplierCommand(int Id, SupplierUpdateDto Supplier) : IRequest;
}