using MediatR;
using smartcoffe.Application.DTOs.Shopping;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Shopping.Commands
{
    public class CreateShoppingCommand : IRequest<int>
    {
        public ShoppingCreateDto Shopping { get; set; }

        public CreateShoppingCommand(ShoppingCreateDto shopping)
        {
            Shopping = shopping;
        }
    }

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
                Promotion = null, // Puedes ajustar esto según sea necesario
                Status = true
            };

            await _unitOfWork.Shoppings.AddAsync(shopping);
            await _unitOfWork.CompleteAsync();

            return shopping.Id;
        }
    }
}