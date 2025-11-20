using MediatR;
using smartcoffe.Application.Features.Inventory.DTOs;

namespace smartcoffe.Application.Features.Inventory.Commands.UpdateInventory
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