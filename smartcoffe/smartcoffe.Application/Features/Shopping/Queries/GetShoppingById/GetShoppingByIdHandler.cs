using MediatR;
using smartcoffe.Application.DTOs.Shopping;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Shopping.Queries.GetShoppingById
{
    public class GetShoppingByIdHandler : IRequestHandler<GetShoppingByIdQuery, ShoppingDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetShoppingByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShoppingDto> Handle(GetShoppingByIdQuery request, CancellationToken cancellationToken)
        {
            var shopping = await _unitOfWork.Shoppings.GetByIdAsync(request.Id);
            if (shopping == null) return null;

            return new ShoppingDto
            {
                Id = shopping.Id,
                Total = shopping.Total,
                Date = shopping.Date,
                Status = shopping.Status
            };
        }
    }
}