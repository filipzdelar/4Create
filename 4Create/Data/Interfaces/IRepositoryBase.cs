using _4Create.Entities.Models;

namespace _4Create.Data.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {

        Task<TEntity> GetByIdAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task SaveChangesAsync();
    }
}
