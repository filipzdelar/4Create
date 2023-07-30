using _4Create.Entities.Enums;
using _4Create.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace _4Create.Data.Interfaces
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<bool> IsEmailUnique(string email);
        Task<bool> EmployeeExistsByTitleAndCompanyIdsAsync(Title title, List<long> companyIds);
    }
}
