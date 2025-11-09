using MediatR;
using smartcoffe.Application.Features.Product.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductListDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Products.GetAllAsync();

            // Filtramos solo los activos y mapeamos al DTO ligero
            var activeProductsDto = products
                .Where(p => p.Status == true)
                .Select(p => new ProductListDto
                {
                    Id = p.Id,
                    Productname = p.Productname,
                    Price = p.Price,
                    Status = p.Status
                })
                .ToList();

            return activeProductsDto;
        }
    }
}