using WebApi_Employees.Models;

namespace WebApi_Employees.Service.EmployeesService
{
    public interface IEmployeesInterface
    {        
        Task<ServiceResponse<List<EmployeesModel>>> GetEmployees();
        Task<ServiceResponse<List<EmployeesModel>>> CreateEmployees(EmployeesModel newEmployees);
        Task<ServiceResponse<EmployeesModel>> GetEmployeesById(int id);
        Task<ServiceResponse<List<EmployeesModel>>> UpdateEmployyes(EmployeesModel updateEmployees);
        Task<ServiceResponse<List<EmployeesModel>>> DeleteEmployeesById(int id);
        Task<ServiceResponse<List<EmployeesModel>>> ActivatedEmployeesById(int id);
    }
}
