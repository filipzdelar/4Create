using _4Create.Data.Interfaces;
using _4Create.Entities.Enums;
using _4Create.Entities.Models;
using _4Create.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace _4Create.Services
{
    public class SystemLogService : ISystemLogService
    {
        private readonly ISystemLogRepository _systemLogRepository;

        public SystemLogService(ISystemLogRepository systemLogRepository)
        {
            _systemLogRepository = systemLogRepository ?? throw new ArgumentNullException(nameof(systemLogRepository));
        }

        public async Task LogNewEmployeeCreationAsync(Employee employee)
        {
            var employeeLog = CreateSystemLog(ResourceType.Employee, employee.Id, "create",
                new { email = employee.Email, title = employee.Title },
                $"New employee {employee.Email} was created.");

            await SaveSystemLogAsync(employeeLog);
        }

        public async Task LogNewCompanyAndEmployeesCreationAsync(Company newCompany)
        {
            var companyLog = CreateSystemLog(ResourceType.Company, newCompany.Id, "create",
                new { name = newCompany.Name },
                $"New company '{newCompany.Name}' was created.");

            await SaveSystemLogAsync(companyLog);

            foreach (var newEmployee in newCompany.Employees)
            {
                await LogNewEmployeeCreationAsync(newEmployee);
            }
        }

        private SystemLog CreateSystemLog(ResourceType resourceType, long resourceId, string @event, object resourceAttributes, string comment)
        {
            return new SystemLog
            {
                ResourceType = resourceType,
                ResourceId = resourceId,
                CreatedAt = DateTime.Now,
                Event = @event,
                ResourceAttributes = System.Text.Json.JsonSerializer.Serialize(resourceAttributes),
                Comment = comment
            };
        }

        private async Task SaveSystemLogAsync(SystemLog systemLog)
        {
            await _systemLogRepository.AddAsync(systemLog);
            await _systemLogRepository.SaveChangesAsync();
        }
    }
}
