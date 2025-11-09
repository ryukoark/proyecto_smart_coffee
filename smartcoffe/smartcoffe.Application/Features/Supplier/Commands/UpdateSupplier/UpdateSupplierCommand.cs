using MediatR;
using smartcoffe.Application.Features.Supplier.DTOs;

namespace smartcoffe.Application.Features.Supplier.Commands.UpdateSupplier
{
    public record UpdateSupplierCommand(int Id, SupplierUpdateDto Supplier) : IRequest;
}