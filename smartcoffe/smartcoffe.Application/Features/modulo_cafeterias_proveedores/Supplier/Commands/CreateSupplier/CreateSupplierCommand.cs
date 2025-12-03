using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.DTOs;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.Commands.CreateSupplier
{
    public record CreateSupplierCommand(SupplierCreateDto Supplier) : IRequest;
}