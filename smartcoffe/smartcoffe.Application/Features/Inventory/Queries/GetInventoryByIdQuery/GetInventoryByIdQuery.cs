using MediatR;
using smartcoffe.Application.Features.Inventory.DTOs;

namespace smartcoffe.Application.Features.Inventory.Queries.GetInventoryByIdQuery
{
    public class GetInventoryByIdQuery : IRequest<InventoryGetDto>
    {
        public int Id { get; set; }

        public GetInventoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}