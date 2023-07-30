using _4Create.Data.Repositories;
using _4Create.Entities.Dtos;
using _4Create.Entities.Models;
using _4Create.Services;
using _4Create.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _4Create.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ILogger<CompaniesController> _logger;
        private readonly ICompanyService _companyService; 
        private readonly ISystemLogService _systemLogService;


        public CompaniesController(ILogger<CompaniesController> logger, ICompanyService companyService, ISystemLogService systemLogService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
            _systemLogService = systemLogService ?? throw new ArgumentNullException(nameof(systemLogService));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyAsync([FromBody] CompanyDto companyDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newCompany = await _companyService.CreateCompanyAsync(companyDto);

                // Log the creation of the new employee.
                await _systemLogService.LogNewCompanyAndEmployeesCreationAsync(newCompany);


                return Ok(newCompany);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the company.");
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred while creating the company.");
            }
        }
    }
}
