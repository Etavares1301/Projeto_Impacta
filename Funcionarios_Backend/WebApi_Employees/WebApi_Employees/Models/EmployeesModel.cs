using System.ComponentModel.DataAnnotations;
using WebApi_Employees.Enums;

namespace WebApi_Employees.Models
{
    public class EmployeesModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DepartmentEnum Department { get; set; }
        public bool Active { get; set; }
        public ShiftEnum Shift { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime UpadateDate { get; set; } = DateTime.Now.ToLocalTime();
    }
}
