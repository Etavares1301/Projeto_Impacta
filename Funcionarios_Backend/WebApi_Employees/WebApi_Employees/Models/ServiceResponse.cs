namespace WebApi_Employees.Models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Sucess { get; set; } = true;
    }
}
