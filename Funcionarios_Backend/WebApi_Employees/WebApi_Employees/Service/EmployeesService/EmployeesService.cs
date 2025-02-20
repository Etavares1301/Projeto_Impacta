using WebApi_Employees.DataContext;
using WebApi_Employees.Models;

namespace WebApi_Employees.Service.EmployeesService
{
    public class EmployeesService : IEmployeesInterface
    {
        private readonly ApplicationDbContext _context;
        public EmployeesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<EmployeesModel>> ActivatedEmployeesById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<EmployeesModel>>> CreateEmployees(EmployeesModel newEmployees)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();
            try
            {
                if (newEmployees == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Informar os dados!";
                    serviceResponse.Sucess= false;
                }
                _context.Add(newEmployees);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Employees.ToList();    
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<EmployeesModel>> DeleteEmployeesById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<EmployeesModel>>> GetEmployees()
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {
                serviceResponse.Dados = _context.Employees.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Message = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex) 
            { 
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<EmployeesModel>> GetEmployeesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<EmployeesModel>>> UpdateEmployyes(EmployeesModel updateEmployees)
        {
            throw new NotImplementedException();
        }
    }
}
