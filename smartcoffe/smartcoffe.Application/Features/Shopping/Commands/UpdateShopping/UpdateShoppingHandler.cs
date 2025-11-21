using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Shopping.Commands.UpdateShopping
{
    public class UpdateShoppingCommandHandler : IRequestHandler<UpdateShoppingCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateShoppingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateShoppingCommand request, CancellationToken cancellationToken)
        {
            var shopping = await _unitOfWork.Shoppings.GetByIdAsync(request.Shopping.Id);
            if (shopping == null) return false;

            shopping.Total = request.Shopping.Total;
            shopping.Date = request.Shopping.Date;
            shopping.Status = request.Shopping.Status;

            _unitOfWork.Shoppings.Update(shopping);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}