using MediatR;
using smartcoffe.Application.DTOs.ShoppingDetail;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.ShoppingDetail.Queries
{
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
    if (shoppingDetail == null)
    {
        throw new KeyNotFoundException($"ShoppingDetail con ID {request.Id} no encontrado.");
    }

    return new ShoppingDetailGetDto
    {
        Id = shoppingDetail.Id,
        ProductName = shoppingDetail.IdProductNavigation?.Productname ?? "Desconocido",
        Price = shoppingDetail.Amount,
        PurchaseDate = shoppingDetail.IdShoppingNavigation?.Date ?? DateTime.MinValue,
        BuyerName = shoppingDetail.IdShoppingNavigation?.IdUserNavigation?.Name ?? "Desconocido",
        PaymentMethod = "Método de pago no especificado"
    };
}
    }
}