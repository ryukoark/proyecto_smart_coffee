using MediatR;
using smartcoffe.Application.Features.modulo_compras.ShoppingDetail.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_compras.ShoppingDetail.Queries
{
    public class GetShoppingDetailByIdQuery : IRequest<ShoppingDetailGetDto>
    {
        public int Id { get; set; }

        public GetShoppingDetailByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetShoppingDetailByIdQueryHandler : IRequestHandler<GetShoppingDetailByIdQuery, ShoppingDetailGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetShoppingDetailByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShoppingDetailGetDto> Handle(GetShoppingDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var shoppingDetail = await _unitOfWork.Repository<Domain.Entities.ShoppingDetail>().GetByIdAsync(request.Id);
            if (shoppingDetail == null) return null;

            return new ShoppingDetailGetDto
            {
                Id = shoppingDetail.Id,
                ProductName = "Example Product",
                Price = 0,
                PurchaseDate = DateTime.Now,
                BuyerName = "Example Buyer",
                PaymentMethod = "Example Payment"
            };
        }
    }
}