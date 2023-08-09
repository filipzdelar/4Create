using _4Create.Data.Interfaces;
using _4Create.Entities.Models;

namespace _4Create.Data.Repositories
{
    public class SystemLogRepository : ISystemLogRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SystemLogRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(SystemLog systemLog)
        {
            await _dbContext.SystemLogs.AddAsync(systemLog);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
