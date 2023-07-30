using _4Create.Data.Interfaces;
using _4Create.Data.Repositories;
using _4Create.Entities.Dtos;
using _4Create.Entities.Models;
using _4Create.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _4Create.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

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

        // You can add other business logic related to companies here
        // For example, methods for updating, deleting, retrieving companies, etc.
    }
}
