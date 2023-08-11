using _4Create.Entities.Models;

namespace _4Create.Services.Interfaces
{
    public interface ISystemLogService
    {
        Task LogNewEmployeeCreationAsync(Employee employee);
        Task LogNewCompanyAndEmployeesCreationAsync(Company newCompany);

    }
}
