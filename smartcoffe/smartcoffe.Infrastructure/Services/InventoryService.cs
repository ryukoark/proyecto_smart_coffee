using smartcoffe.Domain.Entities; 
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Infrastructure.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CheckStockAsync(int productId, int requiredQuantity)
        {
            var repo = _unitOfWork.Repository<Inventory>();

            // Buscar inventario según productId
            var inventoryList = await repo.FindAsync(x => x.Id == productId);

            var inventory = inventoryList.FirstOrDefault();

            if (inventory == null || !inventory.Status)
                return false;

            return inventory.Quantity >= requiredQuantity;
        }

        public async Task ReduceStockAsync(int productId, int quantity)
        {
            var repo = _unitOfWork.Repository<Inventory>();

            var inventoryList = await repo.FindAsync(x => x.Id == productId);
            var inventory = inventoryList.FirstOrDefault();

            if (inventory == null)
                throw new Exception("Product not found in inventory.");

            if (inventory.Quantity < quantity)
                throw new Exception("Not enough stock.");

            inventory.Quantity -= quantity;

            repo.Update(inventory);

            await _unitOfWork.CompleteAsync();
        }
    }
}
