using MediatR;
using smartcoffe.Application.DTOs.ShoppingDetail;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.ShoppingDetail.Commands
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
            var shoppingDetail = new Domain.Entities.ShoppingDetail
            {
                IdProduct = null, // Ajusta según los datos del DTO
                Quantity = 1, // Ajusta según los datos del DTO
                Amount = 0, // Ajusta según los datos del DTO
                Status = true
            };

            await _unitOfWork.Repository<Domain.Entities.ShoppingDetail>().AddAsync(shoppingDetail);
            await _unitOfWork.CompleteAsync();

            return shoppingDetail.Id;
        }
    }
}