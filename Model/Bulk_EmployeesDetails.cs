using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LearningCoreAPI.Model
{
    public class Bulk_EmployeesDetails : IdentityUser
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string EmployeeDepartment { get; set; }
        
    }
}
