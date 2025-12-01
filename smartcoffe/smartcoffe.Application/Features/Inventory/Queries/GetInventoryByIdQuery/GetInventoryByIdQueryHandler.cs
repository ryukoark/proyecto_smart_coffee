using MediatR;
using smartcoffe.Application.Features.Inventory.DTOs;

namespace smartcoffe.Application.Features.Inventory.Queries.GetInventoryByIdQuery
{
    public class GetInventoryByIdQueryHandler 
        : IRequestHandler<GetInventoryByIdQuery, InventoryGetDto>
    {
        public async Task<InventoryGetDto> Handle(
            GetInventoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            // Simulación — luego lo cambias por EF Core
            var data = new InventoryGetDto
            {
                Id = request.Id,
                Quantity = 20,
                IdCafe = 1,
                IdProduct = 5,
                IdSupplier = 2,
                Status = "Active"
            };

            return await Task.FromResult(data);
        }
    }
}