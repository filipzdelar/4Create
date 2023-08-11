using _4Create.Data.Interfaces;
using _4Create.Entities.Enums;
using _4Create.Entities.Interfaces;
using _4Create.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace _4Create.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetByIdAsync(long id)
        {
            return await _dbContext.Set<Employee>().FindAsync(id);
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            return await _dbContext.Employees.AllAsync(e => e.Email != email);
        }

        public async Task<bool> EmployeeExistsByTitleAndCompanyIdsAsync(Title title, List<long> companyIds)
        {
            return await _dbContext.Employees.AnyAsync(e => e.Title == title && e.Companies.Any(ec => companyIds.Contains(ec.Id)));
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbContext.Set<Employee>().ToListAsync();
        }

        public async Task AddAsync(Employee entity)
        {
            await _dbContext.Set<Employee>().AddAsync(entity);
        }

        public async Task UpdateAsync(Employee entity)
        {
            _dbContext.Set<Employee>().Update(entity);
            await Task.CompletedTask; 
        }

        public async Task DeleteAsync(Employee entity)
        {
            _dbContext.Set<Employee>().Remove(entity);
            await Task.CompletedTask; 
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
