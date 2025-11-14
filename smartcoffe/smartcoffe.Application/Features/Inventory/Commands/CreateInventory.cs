using MediatR;
using smartcoffe.Application.Features.Inventory.DTOs;

namespace smartcoffe.Application.Features.Inventory.Commands
{
    public class CreateInventory : IRequest<InventoryGetDto>
    {
        public InventoryCreateDto Dto { get; }

        public CreateInventory(InventoryCreateDto dto)
        {
            Dto = dto;
        }
    }

    public class CreateInventoryHandler : IRequestHandler<CreateInventory, InventoryGetDto>
    {
        public async Task<InventoryGetDto> Handle(CreateInventory request, CancellationToken cancellationToken)
        {
            // Simulación de creación (aquí iría la lógica para guardar en BD)
            var newInventory = new InventoryGetDto
            {
                Id = 1,
                Quantity = request.Dto.Quantity,
                IdCafe = request.Dto.IdCafe,
                IdProduct = request.Dto.IdProduct,
                IdSupplier = request.Dto.IdSupplier,
                Status = "Active"
            };

            return await Task.FromResult(newInventory);
        }
    }
}