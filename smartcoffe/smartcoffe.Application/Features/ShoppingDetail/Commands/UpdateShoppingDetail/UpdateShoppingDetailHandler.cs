using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.ShoppingDetail.Commands.UpdateShoppingDetail
{
    public class UpdateShoppingDetailCommandHandler : IRequestHandler<UpdateShoppingDetailCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateShoppingDetailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateShoppingDetailCommand request, CancellationToken cancellationToken)
        {
            var shoppingDetail = await _unitOfWork.ShoppingDetails.GetByIdAsync(request.ShoppingDetail.Id);
            if (shoppingDetail == null) return false;

            shoppingDetail.Amount = request.ShoppingDetail.Price;

            _unitOfWork.ShoppingDetails.Update(shoppingDetail);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}