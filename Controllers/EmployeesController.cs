using _4Create.Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _4Create.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }

        // GET: api/EmployeesController
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/EmployeesController/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/EmployeesController
        [HttpPost]
        public void Post([FromBody] string value)
        {
           // _logger.LogInformation($"New employee with email '{employee.Email}' and title '{employee.Title}' was created.");
            //return Ok(employee);

        }

        // PUT api/EmployeesController/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/EmployeesController/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
