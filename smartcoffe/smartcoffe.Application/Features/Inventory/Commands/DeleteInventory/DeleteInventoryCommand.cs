using MediatR;

namespace smartcoffe.Application.Features.Inventory.Commands.DeleteInventory
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