using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Shopping.Commands.CreateShopping
{
    public class CreateShoppingCommandHandler : IRequestHandler<CreateShoppingCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateShoppingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateShoppingCommand request, CancellationToken cancellationToken)
        {
            var shopping = new Domain.Entities.Shopping
            {
                Date = DateTime.Now,
                Total = request.Shopping.Price,
                Promotion = null, // Ajustar según sea necesario
                Status = true
            };

            await _unitOfWork.Shoppings.AddAsync(shopping);
            await _unitOfWork.CompleteAsync();

            return shopping.Id;
        }
    }
}