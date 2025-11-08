using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Supplier.Commands.CreateSupplier
{
    public class CreateSupplierHandler : IRequestHandler<CreateSupplierCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSupplierHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Supplier;

            var supplier = new Domain.Entities.Supplier
            {
                Name = dto.Name,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                Status = dto.Status // El DTO ya establece 'true' por defecto
            };

            await _unitOfWork.Suppliers.AddAsync(supplier);
            await _unitOfWork.CompleteAsync();
        }
    }
}