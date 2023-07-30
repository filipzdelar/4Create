using _4Create.Data.Interfaces;
using _4Create.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace _4Create.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Company> GetByIdAsync(long id)
        {
            return await _dbContext.Companies.FindAsync(id);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _dbContext.Companies.ToListAsync();
        }

        public async Task AddAsync(Company entity)
        {
            await _dbContext.Companies.AddAsync(entity);
        }

        public Task UpdateAsync(Company entity)
        {
            // No need to explicitly update companies since Entity Framework will track changes.
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Company entity)
        {
            _dbContext.Companies.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
