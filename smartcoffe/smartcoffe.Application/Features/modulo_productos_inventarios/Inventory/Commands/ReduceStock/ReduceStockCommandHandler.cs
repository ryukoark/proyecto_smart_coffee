using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Commands.ReduceStock;

public class ReduceStockCommandHandler : IRequestHandler<ReduceStockCommand, bool>
{
    private readonly IInventoryService _inventoryService;

    public ReduceStockCommandHandler(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public async Task<bool> Handle(ReduceStockCommand request, CancellationToken cancellationToken)
    {
        await _inventoryService.ReduceStockAsync(request.ProductId, request.Quantity);
        return true;
    }
}
