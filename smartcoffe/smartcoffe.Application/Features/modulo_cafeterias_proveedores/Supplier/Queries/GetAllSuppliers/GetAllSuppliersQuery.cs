using MediatR;
using smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.DTOs;

namespace smartcoffe.Application.Features.modulo_cafeterias_proveedores.Supplier.Queries.GetAllSuppliers
{
    public record GetAllSuppliersQuery() : IRequest<IEnumerable<SupplierListDto>>;
}