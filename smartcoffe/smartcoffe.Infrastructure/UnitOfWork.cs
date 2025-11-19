using System.Collections;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Infrastructure.Persistence;
using smartcoffe.Infrastructure.Repositories;

namespace smartcoffe.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartcoffeDbContext _context;
        
        // Aquí guardaremos los repositorios instanciados en memoria
        private Hashtable _repositories;

        public UnitOfWork(SmartcoffeDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            // Si el repositorio ya existe en memoria, lo devolvemos
            if (_repositories.ContainsKey(type))
            {
                return (IGenericRepository<TEntity>)_repositories[type];
            }

            // Si no existe, creamos una instancia de GenericRepository<TEntity>
            var repositoryType = typeof(GenericRepository<>);
            
            // Esto es equivalente a hacer: new GenericRepository<TEntity>(_context);
            var repositoryInstance = Activator.CreateInstance(
                repositoryType.MakeGenericType(typeof(TEntity)), 
                _context
            );

            // Lo agregamos a la colección
            _repositories.Add(type, repositoryInstance);

            return (IGenericRepository<TEntity>)_repositories[type];
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}