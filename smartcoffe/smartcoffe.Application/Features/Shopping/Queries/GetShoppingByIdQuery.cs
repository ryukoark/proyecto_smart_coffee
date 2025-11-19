using MediatR;
using smartcoffe.Application.DTOs.Shopping;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Shopping.Queries
{
    public class GetShoppingByIdQuery : IRequest<ShoppingGetDto>
    {
        public int Id { get; set; }

        public GetShoppingByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetShoppingByIdQueryHandler : IRequestHandler<GetShoppingByIdQuery, ShoppingGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetShoppingByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShoppingGetDto> Handle(GetShoppingByIdQuery request, CancellationToken cancellationToken)
        {
            var shopping = await _unitOfWork.Repository<Domain.Entities.Shopping>().GetByIdAsync(request.Id);
            if (shopping == null) return null;

            return new ShoppingGetDto
            {
                Id = shopping.Id,
                ProductName = shopping.Promotion ?? "N/A",
                Price = shopping.Total,
                PurchaseDate = shopping.Date
            };
        }
    }
}