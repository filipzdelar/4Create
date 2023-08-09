using _4Create.Entities.Dtos;
using _4Create.Entities.Models;

namespace _4Create.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> CreateCompanyAsync(CompanyDto companyDto);
    }
}
