using MediatR;
using smartcoffe.Application.Features.Inventory.DTOs;

namespace smartcoffe.Application.Features.Inventory.Commands.CreateInventory
{
    public class CreateInventoryCommand : IRequest<InventoryGetDto>
    {
        public InventoryCreateDto Dto { get; }

        public CreateInventoryCommand(InventoryCreateDto dto)
        {
            Dto = dto;
        }
    }
}