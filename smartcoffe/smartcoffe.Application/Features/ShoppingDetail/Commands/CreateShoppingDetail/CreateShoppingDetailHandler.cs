using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.ShoppingDetail.Commands.CreateShoppingDetail
{
    public class CreateShoppingDetailCommandHandler : IRequestHandler<CreateShoppingDetailCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateShoppingDetailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateShoppingDetailCommand request, CancellationToken cancellationToken)
        {
            var shoppingDetail = new smartcoffe.Domain.Entities.ShoppingDetail
            {
                IdProduct = request.ShoppingDetail.IdProduct,
                Quantity = request.ShoppingDetail.Quantity,
                Amount = request.ShoppingDetail.Price,
                IdShopping = request.ShoppingDetail.IdShopping,
                Status = request.ShoppingDetail.Status
            };

            await _unitOfWork.ShoppingDetails.AddAsync(shoppingDetail);
            await _unitOfWork.CompleteAsync();

            return shoppingDetail.Id;
        }
    }
}