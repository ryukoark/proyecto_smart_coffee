using MediatR;
using smartcoffe.Application.Features.Inventory.DTOs;

namespace smartcoffe.Application.Features.Inventory.Commands.CreateInventory
{
    public class CreateInventoryHandler : IRequestHandler<CreateInventoryCommand, InventoryGetDto>
    {
        public async Task<InventoryGetDto> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var newInventory = new InventoryGetDto
            {
                Id = 1, // simulado
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