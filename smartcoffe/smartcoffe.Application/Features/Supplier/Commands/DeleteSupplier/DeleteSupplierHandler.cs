using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Supplier.Commands.DeleteSupplier
{
    public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSupplierHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _unitOfWork.Repository<Domain.Entities.Supplier>().GetByIdAsync(request.Id);

            if (supplier == null)
            {
                throw new KeyNotFoundException($"Proveedor con ID {request.Id} no encontrado.");
            }

            // Soft delete: solo cambiamos el estado
            supplier.Status = false;

            _unitOfWork.Repository<Domain.Entities.Supplier>().Update(supplier);
            await _unitOfWork.CompleteAsync();
        }
    }
}