using MediatR;
using smartcoffe.Application.Features.Inventory.DTOs;

namespace smartcoffe.Application.Features.Inventory.Queries
{
    public class GetInventoryById : IRequest<InventoryGetDto>
    {
        public int Id { get; }

        public GetInventoryById(int id)
        {
            Id = id;
        }
    }

    public class GetInventoryByIdHandler : IRequestHandler<GetInventoryById, InventoryGetDto>
    {
        public async Task<InventoryGetDto> Handle(GetInventoryById request, CancellationToken cancellationToken)
        {
            var inventory = new InventoryGetDto
            {
                Id = request.Id,
                Quantity = 75,
                IdCafe = 1,
                IdProduct = 2,
                IdSupplier = 3,
                Status = "Active"
            };

            return await Task.FromResult(inventory);
        }
    }
}