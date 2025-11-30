using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Supplier.Commands.UpdateSupplier
{
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSupplierHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var existingSupplier = await _unitOfWork.Repository<Domain.Entities.Supplier>().GetByIdAsync(request.Id);

            if (existingSupplier == null)
            {
                throw new KeyNotFoundException($"Proveedor con ID {request.Id} no encontrado.");
            }

            var dto = request.Supplier;

            // Mapeamos los campos del DTO a la entidad existente
            existingSupplier.Name = dto.Name;
            existingSupplier.Address = dto.Address;
            existingSupplier.Phone = dto.Phone;
            existingSupplier.Email = dto.Email;
            existingSupplier.Status = dto.Status;

            _unitOfWork.Repository<Domain.Entities.Supplier>().Update(existingSupplier);
            await _unitOfWork.CompleteAsync();
        }
    }
}