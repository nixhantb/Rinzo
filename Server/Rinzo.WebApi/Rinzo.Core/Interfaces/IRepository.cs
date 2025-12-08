namespace JobLeet.WebApi.JobLeet.Core.Interfaces
{
    /// <summary>
    /// Generic repository interface for basic CRUD operations with separate entity and model types.
    /// </summary>
    /// <typeparam name="TEntity">The entity class representation.</typeparam>
    /// <typeparam name="TModel">The model class representation.</typeparam>
    public interface IRepository<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        Task<TModel> GetByIdAsync(string id);
        Task<List<TModel>> GetAllAsync();
        Task<TModel> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(string id);
    }
}
