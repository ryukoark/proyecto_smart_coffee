using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Dtos;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Queries.GetAllInventoriesQuery
{
    public class GetAllInventoriesQuery : IRequest<IEnumerable<InventoryListDto>>
    {
    }
}