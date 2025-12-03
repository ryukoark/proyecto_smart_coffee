using MediatR;

namespace smartcoffe.Application.Features.modulo_productos_inventarios.Inventory.Commands.DeleteInventory
{
    public class DeleteInventoryCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteInventoryCommand(int id)
        {
            Id = id;
        }
    }
}