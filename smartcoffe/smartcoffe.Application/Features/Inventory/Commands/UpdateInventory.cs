using MediatR;
using smartcoffe.Application.Features.Inventory.DTOs;

namespace smartcoffe.Application.Features.Inventory.Commands
{
    public class UpdateInventory : IRequest<InventoryGetDto>
    {
        public InventoryUpdateDto Dto { get; }

        public UpdateInventory(InventoryUpdateDto dto)
        {
            Dto = dto;
        }
    }

    public class UpdateInventoryHandler : IRequestHandler<UpdateInventory, InventoryGetDto>
    {
        public async Task<InventoryGetDto> Handle(UpdateInventory request, CancellationToken cancellationToken)
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