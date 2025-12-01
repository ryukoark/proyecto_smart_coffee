using MediatR;

namespace smartcoffe.Application.Features.Inventory.Commands.DeleteInventory
{
    public class DeleteInventoryHandler : IRequestHandler<DeleteInventoryCommand, bool>
    {
        public async Task<bool> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            // Simulación de eliminación exitosa
            return await Task.FromResult(true);
        }
    }
}