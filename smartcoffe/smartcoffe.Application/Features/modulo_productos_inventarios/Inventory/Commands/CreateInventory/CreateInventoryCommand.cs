using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Dtos;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Commands.CreateInventory
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