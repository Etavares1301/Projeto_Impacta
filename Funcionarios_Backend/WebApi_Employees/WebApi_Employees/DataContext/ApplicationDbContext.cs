using Microsoft.EntityFrameworkCore;
using WebApi_Employees.Models;

namespace WebApi_Employees.DataContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<EmployeesModel>   Employees { get; set; }
    }
}
