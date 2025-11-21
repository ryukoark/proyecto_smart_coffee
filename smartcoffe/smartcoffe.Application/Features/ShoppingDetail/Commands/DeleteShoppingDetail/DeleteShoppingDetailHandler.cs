using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.ShoppingDetail.Commands.DeleteShoppingDetail
{
    public class DeleteShoppingDetailCommandHandler : IRequestHandler<DeleteShoppingDetailCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteShoppingDetailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteShoppingDetailCommand request, CancellationToken cancellationToken)
        {
            var shoppingDetail = await _unitOfWork.ShoppingDetails.GetByIdAsync(request.Id);
            if (shoppingDetail == null) return false;

            _unitOfWork.ShoppingDetails.Remove(shoppingDetail);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}