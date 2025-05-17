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

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeesModel>>> GetEmPloyessById(int id)
        {
            ServiceResponse<EmployeesModel> serviceResponse = await _employeesInterface.GetEmployeesById(id);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> CreateEmployees(EmployeesModel newEmployees)
        {
            return Ok(await _employeesInterface.CreateEmployees(newEmployees));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> UpdateEmployees(EmployeesModel updateEmployees)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = await _employeesInterface.UpdateEmployees(updateEmployees);
            return Ok(serviceResponse);
        }


        [HttpPut("InactiveEmployeess")]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> ActivatedEmployeesById(int id)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = await _employeesInterface.ActivatedEmployeesById(id);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> DeleteEmployeesById(int id)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = await _employeesInterface.DeleteEmployeesById(id);
            return Ok(serviceResponse);
        }
    }
}
