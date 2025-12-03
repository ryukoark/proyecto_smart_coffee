using MediatR;
using smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Dtos;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Queries.GetInventoryByIdQuery
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