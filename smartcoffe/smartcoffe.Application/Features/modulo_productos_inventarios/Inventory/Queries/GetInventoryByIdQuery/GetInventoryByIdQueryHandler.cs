using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Dtos;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Queries.GetInventoryByIdQuery
{
    public class GetInventoryByIdQueryHandler 
        : IRequestHandler<modulo_productos_inventarios.Inventory.Queries.GetInventoryByIdQuery.GetInventoryByIdQuery, InventoryGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetInventoryByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<InventoryGetDto> Handle(modulo_productos_inventarios.Inventory.Queries.GetInventoryByIdQuery.GetInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            // Repositorio genérico (igual que en Cafes)
            var inventoryRepo = _unitOfWork.Repository<Domain.Entities.Inventory>();

            var inventory = await inventoryRepo.GetByIdAsync(request.Id);

            if (inventory == null)
                return null!;

            // Mapeo respetando tus DTOs no-nullable
            return new InventoryGetDto
            {
                Id = inventory.Id,
                Quantity = inventory.Quantity,
                IdCafe = inventory.IdCafe ?? 0,
                IdProduct = inventory.IdProduct ?? 0,
                IdSupplier = inventory.IdSupplier ?? 0,
                Status = inventory.Status ? "Active" : "Inactive"

            };
        }
    }
}