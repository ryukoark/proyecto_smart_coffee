using MediatR;
using smartcoffe.Application.Features.modulo_compras.Shopping.DTOs;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_compras.Shopping.Queries
{
    public class GetAllShoppingsQuery : IRequest<IEnumerable<ShoppingListDto>>
    {
    }

    public class GetAllShoppingsQueryHandler : IRequestHandler<GetAllShoppingsQuery, IEnumerable<ShoppingListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllShoppingsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ShoppingListDto>> Handle(GetAllShoppingsQuery request, CancellationToken cancellationToken)
        {
            var shoppings = await _unitOfWork.Repository<Domain.Entities.Shopping>().GetAllAsync();

            return shoppings.Select(s => new ShoppingListDto
            {
                Id = s.Id,
                ProductName = s.Promotion ?? "N/A",
                Price = s.Total
            });
        }
    }
}