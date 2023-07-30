using _4Create.Entities.Interfaces;
using _4Create.Entities.Models;

namespace _4Create.Data.Interfaces
{
    public interface ICompanyRepository //: IRepositoryBase<Company>
    {
        Task<Company> GetByIdAsync(long id);
        Task<IEnumerable<Company>> GetAllAsync();
        Task AddAsync(Company entity);
        Task UpdateAsync(Company entity);
        Task DeleteAsync(Company entity);
        Task SaveChangesAsync();
    }
}
