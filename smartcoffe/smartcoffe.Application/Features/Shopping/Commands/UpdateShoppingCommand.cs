using MediatR;
using smartcoffe.Application.DTOs.Shopping;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Shopping.Commands
{
    public class UpdateShoppingCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public ShoppingUpdateDto Shopping { get; set; }

        public UpdateShoppingCommand(int id, ShoppingUpdateDto shopping)
        {
            Id = id;
            Shopping = shopping;
        }
    }

    public class UpdateShoppingCommandHandler : IRequestHandler<UpdateShoppingCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateShoppingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateShoppingCommand request, CancellationToken cancellationToken)
        {
            var shopping = await _unitOfWork.Repository<Domain.Entities.Shopping>().GetByIdAsync(request.Id);
            if (shopping == null) return false;

            shopping.Total = request.Shopping.Price;
            shopping.Promotion = request.Shopping.ProductName;

            _unitOfWork.Repository<Domain.Entities.Shopping>().Update(shopping);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}