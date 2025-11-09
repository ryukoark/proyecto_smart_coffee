using MediatR;
using smartcoffe.Application.Features.Supplier.DTOs;

namespace smartcoffe.Application.Features.Supplier.Queries.GetByIdSupplier
{
    public record GetSupplierByIdQuery(int Id) : IRequest<SupplierDto>;
}