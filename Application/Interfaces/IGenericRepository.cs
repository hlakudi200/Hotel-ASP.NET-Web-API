using Core.Interfaces;

namespace Application.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
