using _4Create.Entities.Models;

namespace _4Create.Data.Interfaces
{
    public interface ISystemLogRepository
    {
        Task AddAsync(SystemLog systemLog);
        Task SaveChangesAsync();
    }
}
