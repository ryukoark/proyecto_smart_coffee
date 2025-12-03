namespace smartcoffe.Domain.Interfaces;

public interface IInventoryService
{
    Task<bool> CheckStockAsync(int productId, int requiredQuantity);
    Task ReduceStockAsync(int productId, int quantity);
}