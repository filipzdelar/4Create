using _4Create.Data.Interfaces;
using _4Create.Data.Repositories;
using _4Create.Entities.Dtos;
using _4Create.Entities.Enums;
using _4Create.Entities.Models;
using _4Create.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace _4Create.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Creates a new company and associates employees with the company.
        /// </summary>
        /// <param name="companyDto">The data transfer object representing the company to be created.</param>
        /// <returns>The newly created company.</returns>
        public async Task<Company> CreateCompanyAsync(CompanyDto companyDto)
        {
            // Create a new company
            var newCompany = _mapper.Map<Company>(companyDto);

            newCompany.CreatedAt = DateTime.Now;

            // Create and associate employees with the company
            var employees = new List<Employee>();

            foreach (var employeeToCreateDto in companyDto.Employees)
            {
                Employee existingEmployee = null;
                if (employeeToCreateDto.Id.HasValue) // Existing employee with ID provided
                {
                    existingEmployee = await _employeeRepository.GetByIdAsync(employeeToCreateDto.Id.Value);
                }

                if (existingEmployee == null) // Employee doesn't exist, create a new one
                {
                    existingEmployee = _mapper.Map<Employee>(employeeToCreateDto);

                    // Don't add employee if manager or tester exists within the company.
                    if (employeeToCreateDto.Title.HasValue && !employeeToCreateDto.Title.Equals(Title.Developer))
                    {
                        // Check if tester or manager has been added previously
                        if (newCompany.Employees.Any(e => e.Title == (Title)employeeToCreateDto.Title))
                        {
                            continue;
                        }

                        // Check database
                        if (await _employeeRepository.EmployeeExistsByTitleAndCompanyIdsAsync((Title)employeeToCreateDto.Title, new List<long> { newCompany.Id }))
                        {
                            continue;
                        }
                    }

                    existingEmployee.CreatedAt = DateTime.Now;
                    await _employeeRepository.AddAsync(existingEmployee);
                }

                // Associate the employee with the company
                newCompany.Employees.Add(existingEmployee);
            }

            await _companyRepository.AddAsync(newCompany);
            await _companyRepository.SaveChangesAsync();

            return newCompany;
        }
    }
}
