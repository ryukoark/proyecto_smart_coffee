using MediatR;
using smartcoffe.Application.DTOs.ShoppingDetail;

namespace smartcoffe.Application.Features.ShoppingDetail.Queries
{
    public class GetAllShoppingDetailsQuery : IRequest<IEnumerable<ShoppingDetailGetDto>>
    {
    }

    public class GetAllShoppingDetailsQueryHandler : IRequestHandler<GetAllShoppingDetailsQuery, IEnumerable<ShoppingDetailGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllShoppingDetailsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ShoppingDetailGetDto>> Handle(GetAllShoppingDetailsQuery request, CancellationToken cancellationToken)
        {
            var shoppingDetails = await _unitOfWork.Products.GetAllAsync();

            return shoppingDetails.Select(s => new ShoppingDetailGetDto
            {
                Id = s.Id,
                ProductName = "Example Product",
                Price = 0,
                PurchaseDate = DateTime.Now,
                BuyerName = "Example Buyer",
                PaymentMethod = "Example Payment"
            });
        }
    }
}