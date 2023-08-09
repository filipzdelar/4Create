using _4Create.Entities.Models;

namespace _4Create.Entities.Dtos
{
    public class CompanyDto
    {
        public string? Name { get; set; }
        public ICollection<EmployeeToCreateDto>? Employees { get; set; }
    }
}
