using _4Create.Data.Interfaces;
using _4Create.Data.Repositories;
using _4Create.Entities.Dtos;
using _4Create.Entities.Enums;
using _4Create.Entities.Models;
using _4Create.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _4Create.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private ICompanyRepository _companyRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, ICompanyRepository companyRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }

        /// <summary>
        /// Creates a new employee based on the provided EmployeeDto.
        /// </summary>
        /// <param name="newEmployeeDto">The EmployeeDto containing employee details.</param>
        /// <returns>The newly created Employee object.</returns>
        public async Task<Employee> CreateEmployeeAsync(EmployeeDto newEmployeeDto)
        {
            var newEmployee = _mapper.Map<Employee>(newEmployeeDto);

            // Associate the employee with the specified companies
            foreach (var companyId in newEmployeeDto.CompanyIds)
            {
                var company = await _companyRepository.GetByIdAsync(companyId);
                if (company != null)
                {
                    newEmployee.Companies.Add(company);
                }
            }

            await _employeeRepository.AddAsync(newEmployee);
            await _employeeRepository.SaveChangesAsync();

            return newEmployee;
        }

        /// <summary>
        /// Checks if the given email is unique among employees.
        /// </summary>
        /// <param name="email">The email to check for uniqueness.</param>
        public async Task<bool> IsEmailUniqueAsync(string? email)
        {
            if (email == null)
            {
                return false;
            }

            return await _employeeRepository.IsEmailUnique(email);
        }

        /// <summary>
        /// Checks if manager or tester aleardy exists within the specified company IDs.
        /// </summary>
        /// <param name="title">The employee title to check for uniqueness.</param>
        /// <param name="companyIds">The list of company IDs to check for title uniqueness.</param>
        /// <returns>True if the title is unique within the specified companies, otherwise false.</returns>
        public async Task<bool> IsTitleUniqueWithinCompanyAsync(Title title, List<long> companyIds)
        {
            if (title.Equals(Title.Developer))
            {
                return false;
            }
            return await _employeeRepository.EmployeeExistsByTitleAndCompanyIdsAsync(title, companyIds);
        }
    }
}
