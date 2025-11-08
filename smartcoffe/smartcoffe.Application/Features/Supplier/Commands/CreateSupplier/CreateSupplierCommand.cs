using MediatR;
using smartcoffe.Application.Features.Supplier.DTOs;

namespace smartcoffe.Application.Features.Supplier.Commands.CreateSupplier
{
    public record CreateSupplierCommand(SupplierCreateDto Supplier) : IRequest;
}