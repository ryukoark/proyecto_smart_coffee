using smartcoffe.Domain.Entities;

namespace smartcoffe.Domain.Interfaces
{
    // Hereda de IDisposable para asegurar que la conexión a la DB se cierre correctamente
    public interface IUnitOfWork : IDisposable
    {
        // 1. Repositorio Genérico expuesto a través de la interfaz.
        // Aquí puedes exponer un repositorio genérico si lo necesitas,
        // pero es más común exponer repositorios específicos.

        // Repositorios Específicos (utilizando el IGenericRepository<T>)
        // Por ejemplo, para la entidad Product:
        IGenericRepository<Product> Products { get; }

        // Puedes añadir más entidades aquí:
        IGenericRepository<Cafe> Cafes { get; }
        // IGenericRepository<User> Users { get; }
        // IGenericRepository<Inventory> Inventories { get; }

        // 2. El método clave para guardar todos los cambios en la transacción.
        Task<int> CompleteAsync();
    }
}