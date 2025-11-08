using Microsoft.EntityFrameworkCore;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Infrastructure.Persistence; // Asumo que DbContext está aquí
using System.Linq.Expressions;

namespace smartcoffe.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // Usamos la interfaz de la capa de Dominio
        protected readonly SmartcoffeDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(SmartcoffeDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            // Nota: El 'Save' o 'Commit' se maneja mejor a nivel de Unit of Work o en el servicio
            // para que varias operaciones sean transaccionales.
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            // Este método asume que la entidad T tiene una clave primaria simple (int id)
            // Para un manejo más genérico, se requeriría una interfaz base para las Entidades.
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            // En EF Core, si la entidad ya está siendo 'tracked' por el contexto,
            // los cambios se guardarán con SaveChanges. Si no, podemos adjuntarla y marcarla.
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}