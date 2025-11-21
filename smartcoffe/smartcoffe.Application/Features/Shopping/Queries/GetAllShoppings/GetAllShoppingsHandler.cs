using MediatR;
using smartcoffe.Application.DTOs.Shopping;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.Shopping.Queries.GetAllShoppings
{
    public class GetAllShoppingsHandler : IRequestHandler<GetAllShoppingsQuery, List<ShoppingDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllShoppingsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ShoppingDto>> Handle(GetAllShoppingsQuery request, CancellationToken cancellationToken)
        {
            // Obtener todas las entidades de Shopping
            var shoppings = await _unitOfWork.Shoppings.GetAllAsync();

            // Validar que la lista no sea nula
            if (shoppings == null || !shoppings.Any())
            {
                return new List<ShoppingDto>(); // Retornar una lista vacía si no hay datos
            }

            // Mapear las entidades a DTOs
            return shoppings.Select(s => new ShoppingDto
            {
                Id = s.Id,
                Total = s.Total,
                Date = s.Date,
                Status = s.Status
            }).ToList();
        }
    }
}