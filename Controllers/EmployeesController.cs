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
        private readonly IMapper _mapper;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeService employeeService, IMapper mapper)
        {
            _logger = logger;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        /*
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var employees = _employeeService.GetAllEmployees();
            return employees;
        }*/

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                // Perform validation if required.
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var newEmployee = _mapper.Map<Employee>(employeeDto);

                // Call the service method to create the employee.
                var createdEmployee = await _employeeService.CreateEmployeeAsync(newEmployee);


                // You can return the created employee or just an OK response.
                // Adjust the response based on your API design requirements.
                return Ok(createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred while creating the employee.");
            }

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
