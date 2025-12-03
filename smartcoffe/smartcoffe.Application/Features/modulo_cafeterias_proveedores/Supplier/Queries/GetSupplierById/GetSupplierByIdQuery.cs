using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.DTOs;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.Queries.GetSupplierById
{
    public record GetSupplierByIdQuery(int Id) : IRequest<SupplierDto>;
}