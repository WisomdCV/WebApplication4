using System.Linq.Expressions;

namespace WISOMAPP.Application.Interfaces
{
    // Esta interfaz define operaciones genéricas para una entidad 'T'
    public interface IGenericRepository<T> where T : class
    {
        // Obtener una entidad por su ID (para llaves primarias tipo Guid)
        Task<T?> GetByIdAsync(Guid id);

        // Obtener todas las entidades
        Task<IEnumerable<T>> GetAllAsync();

        // Obtener entidades que cumplen una condición
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // Añadir una nueva entidad
        void AddEntity(T entity);

        // Añadir un rango de entidades
        void AddRange(IEnumerable<T> entities);

        // Marcar una entidad como modificada
        void UpdateEntity(T entity);

        // Eliminar una entidad
        void RemoveEntity(T entity);

        // Eliminar un rango de entidades
        void RemoveRange(IEnumerable<T> entities);
    }
}