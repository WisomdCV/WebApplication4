namespace WISOMAPP.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;

        // Este es el método más importante.
        // Guardará todos los cambios (Adds, Updates, Removes) 
        // en la base de datos en una sola transacción.
        Task<int> Complete();
    }
}