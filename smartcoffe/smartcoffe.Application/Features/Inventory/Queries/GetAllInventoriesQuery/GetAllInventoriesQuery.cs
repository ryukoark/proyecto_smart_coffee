using MediatR;
using smartcoffe.Application.Features.Inventory.DTOs;

namespace smartcoffe.Application.Features.Inventory.Queries.GetAllInventoriesQuery
{
    public class GetAllInventoriesQuery : IRequest<IEnumerable<InventoryListDto>>
    {
    }
}