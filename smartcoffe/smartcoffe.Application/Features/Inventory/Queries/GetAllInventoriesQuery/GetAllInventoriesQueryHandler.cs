using MediatR;
using smartcoffe.Application.Features.Inventory.DTOs;

namespace smartcoffe.Application.Features.Inventory.Queries.GetAllInventoriesQuery
{
    public class GetAllInventoriesQueryHandler 
        : IRequestHandler<GetAllInventoriesQuery, IEnumerable<InventoryListDto>>
    {
        public async Task<IEnumerable<InventoryListDto>> Handle(
            GetAllInventoriesQuery request,
            CancellationToken cancellationToken)
        {
            // Simulación — luego lo conectas a la DB
            var data = new List<InventoryListDto>
            {
                new InventoryListDto { Id = 1, Quantity = 50, IdCafe = 1, IdProduct = 2, IdSupplier = 1, Status = "Active" }
            };

            return await Task.FromResult(data);
        }
    }
}