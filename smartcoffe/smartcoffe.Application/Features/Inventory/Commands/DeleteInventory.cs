using MediatR;

namespace smartcoffe.Application.Features.Inventory.Commands
{
    public class DeleteInventory : IRequest<bool>
    {
        public int Id { get; }

        public DeleteInventory(int id)
        {
            Id = id;
        }
    }

    public class DeleteInventoryHandler : IRequestHandler<DeleteInventory, bool>
    {
        public async Task<bool> Handle(DeleteInventory request, CancellationToken cancellationToken)
        {
            // Simulación de eliminación exitosa
            return await Task.FromResult(true);
        }
    }
}