using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Employees.Models;
using WebApi_Employees.Service.EmployeesService;

namespace WebApi_Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesInterface _employeesInterface;
        public EmployeesController(IEmployeesInterface employeesInterface)
        {
            _employeesInterface = employeesInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> GetEmployees()
        {
            return Ok(await _employeesInterface.GetEmployees());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> CreateEmployees(EmployeesModel newEmployees)
        {
            return Ok(await _employeesInterface.CreateEmployees(newEmployees));
        }
    }
}
