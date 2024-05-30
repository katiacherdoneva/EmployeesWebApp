using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Web.Api.CsvHelper.Conf;
using Web.Api.Interfaces;
using Web.Api.Models;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _empServices;

        public EmployeeController(IEmployeeService empServices)
        {
            _empServices = empServices;
        }

        [HttpPost("getLongestWorkingPair")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Get(IFormFile employeesFile)
        {
            if (employeesFile == null || employeesFile.Length == 0)
                BadRequest("No file uploaded.");

            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                TrimOptions = TrimOptions.Trim,
                HeaderValidated = null,
                MissingFieldFound = null
            };

            var employees = new List<EmployeeModel>();
            using (var stream = new StreamReader(employeesFile.OpenReadStream()))
            using (var csvReader = new CsvReader(stream, csvConfiguration))
            {
                csvReader.Context.RegisterClassMap<EmployeeModelMap>();
                employees = csvReader.GetRecords<EmployeeModel>().ToList();
            }
            var result = _empServices.GetLongestWorkingPair(employees);
            if (result == null)
                return NotFound("No overlapping work periods found.");

            return Ok(result);
        }
    }
}
