using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Repository<Domain.Entities.Product>().GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Producto con ID {request.Id} no encontrado.");
            }

            // Soft delete: solo cambiamos el estado
            product.Status = false;

            _unitOfWork.Repository<Domain.Entities.Product>().Update(product);
            await _unitOfWork.CompleteAsync();
        }
    }
}