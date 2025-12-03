using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Dtos;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Commands.UpdateInventory
{
    public class UpdateInventoryHandler : IRequestHandler<UpdateInventoryCommand, InventoryGetDto>
    {
        public async Task<InventoryGetDto> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var updatedInventory = new InventoryGetDto
            {
                Id = request.Dto.Id,
                Quantity = request.Dto.Quantity,
                IdCafe = request.Dto.IdCafe,
                IdProduct = request.Dto.IdProduct,
                IdSupplier = request.Dto.IdSupplier,
                Status = request.Dto.Status
            };

            return await Task.FromResult(updatedInventory);
        }
    }
}