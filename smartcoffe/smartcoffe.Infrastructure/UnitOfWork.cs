using smartcoffe.Domain.Interfaces;
using smartcoffe.Domain.Entities;
using smartcoffe.Infrastructure.Persistence;
using smartcoffe.Infrastructure.Repositories; // Tu DbContext

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

        private IGenericRepository<Supplier>? _suppliers; // <-- Linea agregada

        private IGenericRepository<Category>? _categories;


        public UnitOfWork(SmartcoffeDbContext context)
        {
            _context = context;
        }

        // Implementación de la propiedad Products con inicialización lazy
        public IGenericRepository<Product> Products
        {
            get { return _products ??= new Repositories.GenericRepository<Product>(_context); }
        }
        public IGenericRepository<Category> Categories
        {
            get { return _categories ??= new GenericRepository<Category>(_context); }
        }
        
        // Implementación de la propiedad Cafes
        public IGenericRepository<Cafe> Cafes
        {
            get { return _cafes ??= new Repositories.GenericRepository<Cafe>(_context); }
        }

        public IGenericRepository<Promotion> Promotions
        {
            get { return _promotions ??= new Repositories.GenericRepository<Promotion>(_context); }
        }
        
        public IGenericRepository<Supplier> Suppliers
        {
            get { return _suppliers ??= new Repositories.GenericRepository<Supplier>(_context); }
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
    }
}