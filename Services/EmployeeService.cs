using _4Create.Data.Interfaces;
using _4Create.Entities.Dtos;
using _4Create.Entities.Enums;
using _4Create.Entities.Models;
using _4Create.Services.Interfaces;
using AutoMapper;

namespace _4Create.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        /*
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public void AddEmployee(Employee employee)
        {
            // Add any additional business logic here before saving
            _employeeRepository.Add(employee);
            _employeeRepository.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            // Add any additional business logic here before updating
            _employeeRepository.Update(employee);
            _employeeRepository.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                // Optionally, handle the case when the employee with the specified ID is not found.
                throw new ArgumentException("Employee not found.", nameof(id));
            }

            // Add any additional business logic here before deleting
            _employeeRepository.Delete(employee);
            _employeeRepository.SaveChanges();
        }
        */

        public async Task<Employee> CreateEmployeeAsync(EmployeeDto newEmployeeDto)
        {
            var newEmployee = _mapper.Map<Employee>(newEmployeeDto);
            await _employeeRepository.AddAsync(newEmployee);
            await _employeeRepository.SaveChangesAsync();

            return newEmployee;
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return await _employeeRepository.IsEmailUnique(email);
        }

        public async Task<bool> IsTitleUniqueWithinCompanyAsync(Title title, List<long> companyIds)
        {
            if(title.Equals(Title.Developer))
            {
                return true;
            }

            return await _employeeRepository.EmployeeExistsByTitleAndCompanyIdsAsync(title, companyIds);
        }

    }
}
