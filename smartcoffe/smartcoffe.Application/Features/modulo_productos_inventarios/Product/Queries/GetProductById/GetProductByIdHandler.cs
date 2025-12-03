using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Product.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Product.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Repository<Domain.Entities.Product>().GetByIdAsync(request.Id);

            if (product == null || !product.Status)
            {
                throw new KeyNotFoundException($"Producto con ID {request.Id} no encontrado o está inactivo.");
            }

            // Mapeamos al DTO detallado
            var dto = new ProductDto
            {
                Id = product.Id,
                Productname = product.Productname,
                Expirationdate = product.Expirationdate,
                Price = product.Price,
                IdCategory = product.IdCategory,
                IdPromotion = product.IdPromotion,
                Status = product.Status,
                Img = product.Img,
            };

            return dto;
        }
    }
}