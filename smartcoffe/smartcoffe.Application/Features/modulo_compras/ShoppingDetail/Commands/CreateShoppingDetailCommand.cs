// ...existing code...

using MediatR;
using smartcoffe.Application.Features.modulo_compras.ShoppingDetail.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_compras.ShoppingDetail.Commands
{
    public class CreateShoppingDetailCommand : IRequest<int>
    {
        public ShoppingDetailCreateDto ShoppingDetail { get; set; }

        public CreateShoppingDetailCommand(ShoppingDetailCreateDto shoppingDetail)
        {
            ShoppingDetail = shoppingDetail;
        }
    }

    public class CreateShoppingDetailCommandHandler : IRequestHandler<CreateShoppingDetailCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateShoppingDetailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateShoppingDetailCommand request, CancellationToken cancellationToken)
        {
            var dto = request.ShoppingDetail;

            var shoppingDetail = new Domain.Entities.ShoppingDetail
            {
                IdProduct = dto.IdProduct,
                Quantity = dto.Quantity,
                Amount = dto.Price * dto.Quantity,
                IdShopping = dto.IdShopping,
                Status = true
                // Si decides persistir BuyerName/PaymentMethod, añade propiedades en la entidad y asigna aquí.
            };

            await _unitOfWork.Repository<Domain.Entities.ShoppingDetail>().AddAsync(shoppingDetail);
            await _unitOfWork.CompleteAsync();

            return shoppingDetail.Id;
        }
    }
}
// ...existing code...