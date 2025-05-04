using Microsoft.EntityFrameworkCore;
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

        public async Task<ServiceResponse<List<EmployeesModel>>> ActivatedEmployeesById(int id)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try 
            {
                EmployeesModel functionary = _context.Employees.FirstOrDefault(x => x.Id == id);

                if(functionary == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Funcionário não encontrado!";
                    serviceResponse.Sucess = false;

                    return serviceResponse;

                }
                functionary.Active = false;
                functionary.UpadateDate = DateTime.Now.ToLocalTime();

                _context.Employees.Update(functionary);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Employees.ToList();

            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;

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

                    return serviceResponse;

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

        public async Task<ServiceResponse<List<EmployeesModel>>> DeleteEmployeesById(int id)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {
                EmployeesModel functionary = _context.Employees.FirstOrDefault(x => x.Id == id);

                if (functionary == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Funcionário não encontrado!";
                    serviceResponse.Sucess = false;

                }

                _context.Employees.Remove(functionary);
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

        public async Task<ServiceResponse<EmployeesModel>> GetEmployeesById(int id)
        {
            ServiceResponse<EmployeesModel> serviceResponse = new ServiceResponse<EmployeesModel>();

            try
            {
                EmployeesModel functionary = _context.Employees.FirstOrDefault(x => x.Id == id);
                
                if (functionary == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Funcionário não encontrado!";
                    serviceResponse.Sucess = false ;
                }
                serviceResponse.Dados = functionary;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeesModel>>> UpdateEmployyes(EmployeesModel updateEmployees)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {
                EmployeesModel functionary = _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == updateEmployees.Id);

                if (functionary == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Funcionário não encontrado!";
                    serviceResponse.Sucess = false;

                    return serviceResponse;

                }
                functionary.UpadateDate = DateTime.Now.ToLocalTime();
                _context.Employees.Update(functionary);


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


    }
}

