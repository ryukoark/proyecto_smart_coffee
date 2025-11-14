using MediatR;
using smartcoffe.Application.Features.Inventory.DTOs;

namespace smartcoffe.Application.Features.Inventory.Queries
{
    public class GetAllInventories : IRequest<IEnumerable<InventoryListDto>> { }

    public class GetAllInventoriesHandler : IRequestHandler<GetAllInventories, IEnumerable<InventoryListDto>>
    {
        public async Task<IEnumerable<InventoryListDto>> Handle(GetAllInventories request, CancellationToken cancellationToken)
        {
            // Ejemplo simulado (luego se reemplaza por consulta real)
            var inventories = new List<InventoryListDto>
            {
                new InventoryListDto { Id = 1, Quantity = 50, IdCafe = 1, IdProduct = 2, IdSupplier = 3, Status = "Active" },
                new InventoryListDto { Id = 2, Quantity = 100, IdCafe = 2, IdProduct = 4, IdSupplier = 1, Status = "Active" }
            };

            return await Task.FromResult(inventories);
        }
    }
}