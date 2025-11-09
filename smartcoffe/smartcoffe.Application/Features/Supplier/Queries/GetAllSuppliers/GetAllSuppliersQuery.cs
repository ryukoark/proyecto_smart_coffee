using MediatR;
using smartcoffe.Application.Features.Supplier.DTOs;

namespace smartcoffe.Application.Features.Supplier.Queries.GetSupplier
{
    public record GetAllSuppliersQuery() : IRequest<IEnumerable<SupplierListDto>>;
}