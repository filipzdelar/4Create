﻿using _4Create.Entities.Dtos;
using _4Create.Entities.Enums;
using _4Create.Entities.Models;

namespace _4Create.Services.Interfaces
{
    public interface IEmployeeService
    {
        /*
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);*/
        Task<Employee> CreateEmployeeAsync(EmployeeDto newEmployee);
        Task<bool> IsEmailUniqueAsync(string? email);
        Task<bool> IsTitleUniqueWithinCompanyAsync(Title title, List<long> companyIds);
    }
}
