using MediatR;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Commands.CheckStock;

public class CheckStockCommandHandler : IRequestHandler<CheckStockCommand, bool>
{
    private readonly IInventoryService _inventoryService;

    public CheckStockCommandHandler(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public async Task<bool> Handle(CheckStockCommand request, CancellationToken cancellationToken)
    {
        return await _inventoryService.CheckStockAsync(
            request.ProductId,
            request.Quantity
        );
    }
}