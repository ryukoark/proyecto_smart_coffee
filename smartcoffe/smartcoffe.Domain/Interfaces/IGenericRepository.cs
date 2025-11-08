using System.Linq.Expressions;

namespace smartcoffe.Domain.Interfaces
{
    // T debe ser una clase, es el tipo de la entidad (e.g., Cafe, Product)
    public interface IGenericRepository<T> where T : class
    {
        // Obtiene todas las entidades
        Task<IEnumerable<T>> GetAllAsync();

        // Obtiene una entidad por su ID (asumimos que la entidad tiene una propiedad de ID)
        Task<T?> GetByIdAsync(int id);

        // Busca entidades basándose en una condición
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // Agrega una nueva entidad
        Task AddAsync(T entity);

        // Agrega un rango de entidades
        Task AddRangeAsync(IEnumerable<T> entities);

        // Actualiza una entidad
        void Update(T entity);

        // Elimina una entidad
        void Remove(T entity);

        // Elimina un rango de entidades
        void RemoveRange(IEnumerable<T> entities);
    }
}