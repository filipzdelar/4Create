using _4Create.Data.Repositories;
using _4Create.Entities.Dtos;
using _4Create.Entities.Models;
using _4Create.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _4Create.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly ISystemLogService _systemLogService;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeService employeeService, ISystemLogService systemLogService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _systemLogService = systemLogService ?? throw new ArgumentNullException(nameof(systemLogService));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] EmployeeDto employeeDto)
        {
            //try
            //{
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Check if the employee email is unique.
                if (!await _employeeService.IsEmailUniqueAsync(employeeDto.Email))
                {
                    return Conflict("Employee email must be unique.");
                }

                // Don't add employee if manager or tester exist within company.
                if (await _employeeService.IsTitleUniqueWithinCompanyAsync(employeeDto.Title, employeeDto.CompanyIds))
                {
                    return Conflict("Employee title must be unique within the company.");
                }

                // Create a new employee and add it to the specified companies.
                var createdEmployee = await _employeeService.CreateEmployeeAsync(employeeDto);

                // Log the creation of the new employee.
                await _systemLogService.LogNewEmployeeCreationAsync(createdEmployee);

                // Return a 201 Created response with the created resource and the Location header.
                return Ok("New employee with email " + createdEmployee.Email + " has been created");
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "An error occurred while creating the employee.");
            //    return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred while creating the employee.");
            //}
        }
    }
}
