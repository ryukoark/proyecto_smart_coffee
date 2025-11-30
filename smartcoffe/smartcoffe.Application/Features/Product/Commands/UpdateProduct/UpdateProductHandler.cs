using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _unitOfWork.Repository<Domain.Entities.Product>().GetByIdAsync(request.Id);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Producto con ID {request.Id} no encontrado.");
            }

            var dto = request.Product;

            // Mapeamos los campos del DTO a la entidad existente
            existingProduct.Productname = dto.Productname;
            existingProduct.Expirationdate = dto.Expirationdate;
            existingProduct.Price = dto.Price;
            existingProduct.IdCategory = dto.IdCategory;
            existingProduct.IdPromotion = dto.IdPromotion;
            existingProduct.Status = dto.Status;

            _unitOfWork.Repository<Domain.Entities.Product>().Update(existingProduct);
            await _unitOfWork.CompleteAsync();
        }
    }
}