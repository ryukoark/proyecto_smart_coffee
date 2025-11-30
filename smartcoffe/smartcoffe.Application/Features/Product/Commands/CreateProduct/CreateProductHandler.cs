using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Product;

            var product = new Domain.Entities.Product
            {
                Productname = dto.Productname,
                Expirationdate = dto.Expirationdate,
                Price = dto.Price,
                IdCategory = dto.IdCategory,
                IdPromotion = dto.IdPromotion,
                Status = dto.Status // El DTO ya establece 'true' por defecto
            };
            
            // Nota: No establecemos el ID. La base de datos (SERIAL) lo generará automáticamente.

            await _unitOfWork.Repository<Domain.Entities.Product>().AddAsync(product);
            await _unitOfWork.CompleteAsync();
        }
    }
}