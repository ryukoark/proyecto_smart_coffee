using smartcoffe.Domain.Entities;

namespace smartcoffe.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Repositorios Específicos
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Cafe> Cafes { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<User> Users { get; } 
        IGenericRepository<Inventory> Inventories { get; } 
        IGenericRepository<Promotion> Promotions { get; }
        IGenericRepository<Supplier> Suppliers { get; }

        IGenericRepository<PurchaseHistory> PurchaseHistories { get; }
        
        IGenericRepository<Shopping> Shoppings { get; }
        
        IGenericRepository<ShoppingDetail> ShoppingDetails { get; }

        Task<int> CompleteAsync();
    }
}