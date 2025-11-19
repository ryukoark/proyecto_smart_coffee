using smartcoffe.Domain.Interfaces;
using smartcoffe.Domain.Entities;

namespace smartcoffe.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Este método mágico reemplaza a todas las propiedades individuales
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> CompleteAsync();
    }
}