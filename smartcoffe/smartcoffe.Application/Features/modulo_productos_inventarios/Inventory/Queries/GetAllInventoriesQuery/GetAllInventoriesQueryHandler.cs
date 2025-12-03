using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Dtos;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Queries.GetAllInventoriesQuery
{
    public class GetAllInventoriesQueryHandler 
        : IRequestHandler<modulo_productos_inventarios.Inventory.Queries.GetAllInventoriesQuery.GetAllInventoriesQuery, IEnumerable<InventoryListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllInventoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<InventoryListDto>> Handle(
            modulo_productos_inventarios.Inventory.Queries.GetAllInventoriesQuery.GetAllInventoriesQuery request,
            CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Domain.Entities.Inventory>();
            var inventories = await repo.GetAllAsync();

            return inventories.Select(i => new InventoryListDto
            {
                Id = i.Id,
                Quantity = i.Quantity,
                IdCafe = i.IdCafe ?? 0,
                IdProduct = i.IdProduct ?? 0,
                IdSupplier = i.IdSupplier ?? 0,
                Status = i.Status ? "Active" : "Inactive"
            });
        }
    }
}