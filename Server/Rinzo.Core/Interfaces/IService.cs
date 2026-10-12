namespace Rinzo.Core.Interfaces
{
    /// <summary>
    /// Generic service interface for basic CRUD operations and business logic.
    /// </summary>
    /// <typeparam name="T">The entity class representation.</typeparam>
    public interface IService<T>
        where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
    }
}
