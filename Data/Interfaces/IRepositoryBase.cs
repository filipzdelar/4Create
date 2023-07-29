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

        /*
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity employee);
        void Update(TEntity employee);
        void Delete(TEntity employee);
        void SaveChanges();*/
    }
}
