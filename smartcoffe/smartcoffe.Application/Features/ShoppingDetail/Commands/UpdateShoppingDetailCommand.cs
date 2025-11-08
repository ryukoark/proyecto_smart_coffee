using MediatR;
using smartcoffe.Application.DTOs.ShoppingDetail;

namespace smartcoffe.Application.Features.ShoppingDetail.Commands
{
    public class UpdateShoppingDetailCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public ShoppingDetailCreateDto ShoppingDetail { get; set; }

        public UpdateShoppingDetailCommand(int id, ShoppingDetailCreateDto shoppingDetail)
        {
            Id = id;
            ShoppingDetail = shoppingDetail;
        }
    }

    public class UpdateShoppingDetailCommandHandler : IRequestHandler<UpdateShoppingDetailCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateShoppingDetailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateShoppingDetailCommand request, CancellationToken cancellationToken)
        {
            var shoppingDetail = await _unitOfWork.Products.GetByIdAsync(request.Id);
            if (shoppingDetail == null) return false;

            shoppingDetail.Quantity = 1; // Ajusta según los datos del DTO
            shoppingDetail.Amount = 0; // Ajusta según los datos del DTO

            _unitOfWork.Products.Update(shoppingDetail);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}