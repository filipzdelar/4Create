using _4Create.Data.Interfaces;
using _4Create.Entities.Enums;
using _4Create.Entities.Models;
using _4Create.Services.Interfaces;

namespace _4Create.Services
{
    public class SystemLogService : ISystemLogService
    {
        private readonly ISystemLogRepository _systemLogRepository;

        public SystemLogService(ISystemLogRepository systemLogRepository)
        {
            _systemLogRepository = systemLogRepository;
        }

        public async Task LogNewEmployeeCreationAsync(Employee employee)
        {
            var newLog = new SystemLog
            {
                ResourceType = ResourceType.Employee,
                ResourceId = employee.Id,
                CreatedAt = DateTime.UtcNow,
                Event = "create",
                ResourceAttributes = $"{{\"email\": \"{employee.Email}\", \"title\": \"{employee.Title}\"}}",
                Comment = $"new employee {employee.Email} was created"
            };

            await _systemLogRepository.AddAsync(newLog);
            await _systemLogRepository.SaveChangesAsync();
        }
    }
}
