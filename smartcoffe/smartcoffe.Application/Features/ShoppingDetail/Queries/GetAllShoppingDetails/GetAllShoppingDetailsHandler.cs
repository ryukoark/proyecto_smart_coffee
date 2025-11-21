using MediatR;
using smartcoffe.Application.DTOs.ShoppingDetail;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.ShoppingDetail.Queries.GetAllShoppingDetails
{
    public class GetAllShoppingDetailsHandler : IRequestHandler<GetAllShoppingDetailsQuery, IEnumerable<ShoppingDetailGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllShoppingDetailsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ShoppingDetailGetDto>> Handle(GetAllShoppingDetailsQuery request, CancellationToken cancellationToken)
        {
            var shoppingDetails = await _unitOfWork.ShoppingDetails.GetAllAsync();

            return shoppingDetails.Select(s => new ShoppingDetailGetDto
            {
                Id = s.Id,
                ProductName = s.IdProductNavigation?.Productname ?? "Desconocido",
                Price = s.Amount,
                PurchaseDate = s.IdShoppingNavigation?.Date ?? DateTime.MinValue,
                BuyerName = s.IdShoppingNavigation?.IdUserNavigation?.Name ?? "Desconocido",
                PaymentMethod = "Método de pago no especificado"
            });
        }
    }
}