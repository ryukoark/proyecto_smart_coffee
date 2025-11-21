using smartcoffe.Domain.Interfaces;
using smartcoffe.Domain.Entities;
using smartcoffe.Infrastructure.Persistence; 
using smartcoffe.Infrastructure.Repositories; 

namespace smartcoffe.Infrastructure
{
    // NOTA: Asume que la implementación GenericRepository está en smartcoffe.Infrastructure/Repositories/
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartcoffeDbContext _context;

        // Propiedades de Repositorios (lazy-loading en la inicialización)
        private IGenericRepository<Product>? _products;
        private IGenericRepository<Cafe>? _cafes;
        private IGenericRepository<Promotion>? _promotions;
        private IGenericRepository<Supplier>? _suppliers;
        private IGenericRepository<Category>? _categories;
        private IGenericRepository<User>? _users; 
        private IGenericRepository<Inventory>? _inventories; 
        private IGenericRepository<PurchaseHistory>? _purchaseHistories;
        private IGenericRepository<Shopping>? _shoppings;
        private IGenericRepository<ShoppingDetail>? _shoppingDetails;

        public UnitOfWork(SmartcoffeDbContext context)
        {
            _context = context;
        }

        // Implementación de las propiedades
        public IGenericRepository<Product> Products
        {
            get { return _products ??= new GenericRepository<Product>(_context); }
        }
        
        // Implementación de la propiedad Cafes
        public IGenericRepository<Cafe> Cafes
        {
            get { return _cafes ??= new GenericRepository<Cafe>(_context); }
        }
        public IGenericRepository<Category> Categories
        {
            get { return _categories ??= new GenericRepository<Category>(_context); }
        }
        public IGenericRepository<User> Users
        {
            get { return _users ??= new GenericRepository<User>(_context); }
        }
        public IGenericRepository<Inventory> Inventories
        {
            get { return _inventories ??= new GenericRepository<Inventory>(_context); }
        }
        public IGenericRepository<Promotion> Promotions
        {
            get { return _promotions ??= new GenericRepository<Promotion>(_context); }
        }
        public IGenericRepository<Supplier> Suppliers
        {
            get { return _suppliers ??= new GenericRepository<Supplier>(_context); }
        }
        public IGenericRepository<PurchaseHistory> PurchaseHistories
        {
            get { return _purchaseHistories ??= new GenericRepository<PurchaseHistory>(_context); }
        }
        public IGenericRepository<Shopping> Shoppings
        {
            get { return _shoppings ??= new GenericRepository<Shopping>(_context); }
        }
        public IGenericRepository<ShoppingDetail> ShoppingDetails
        {
            get { return _shoppingDetails ??= new GenericRepository<ShoppingDetail>(_context); }
        }

        
        // Este método ejecuta el SaveChanges de EF Core, guardando la transacción
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Implementación de IDisposable para liberar recursos
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }
    }
}