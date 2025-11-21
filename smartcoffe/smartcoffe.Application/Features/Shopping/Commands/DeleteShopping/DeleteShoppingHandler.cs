using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Shopping.Commands.DeleteShopping
{
    public class DeleteShoppingCommandHandler : IRequestHandler<DeleteShoppingCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteShoppingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteShoppingCommand request, CancellationToken cancellationToken)
        {
            var shopping = await _unitOfWork.Shoppings.GetByIdAsync(request.Id);
            if (shopping == null) return false;

            _unitOfWork.Shoppings.Remove(shopping);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}