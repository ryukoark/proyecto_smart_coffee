using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Dtos;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Commands.UpdateInventory
{
    public class UpdateInventoryCommand : IRequest<InventoryGetDto>
    {
        public InventoryUpdateDto Dto { get; }

        public UpdateInventoryCommand(InventoryUpdateDto dto)
        {
            Dto = dto;
        }
    }
}