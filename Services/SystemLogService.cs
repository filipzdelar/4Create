using _4Create.Data.Interfaces;
using _4Create.Entities.Enums;
using _4Create.Entities.Models;
using _4Create.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var employeeLog = new SystemLog
            {
                ResourceType = ResourceType.Employee,
                ResourceId = employee.Id,
                CreatedAt = DateTime.UtcNow,
                Event = "create",
                ResourceAttributes = $"{{\"email\": \"{employee.Email}\", \"title\": \"{employee.Title}\"}}",
                Comment = $"new employee {employee.Email} was created"
            };

            await _systemLogRepository.AddAsync(employeeLog);
            await _systemLogRepository.SaveChangesAsync();
        }

        public async Task LogNewCompanyAndEmployeesCreationAsync(Company newCompany)
        {
            // Log the creation of the new company
            var companyLog = new SystemLog
            {
                ResourceType = ResourceType.Company,
                ResourceId = newCompany.Id,
                CreatedAt = DateTime.UtcNow,
                Event = "create",
                ResourceAttributes = $"{{\"name\": \"{newCompany.Name}\"}}",
                Comment = $"New company '{newCompany.Name}' was created."
            };

            await _systemLogRepository.AddAsync(companyLog);
            await _systemLogRepository.SaveChangesAsync();

            foreach (var newEmployee in newCompany.Employees)
            {
                await LogNewEmployeeCreationAsync(newEmployee);
            }

        }
    }
}
