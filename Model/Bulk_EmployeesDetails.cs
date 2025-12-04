using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LearningCoreAPI.Model
{
    public class Bulk_EmployeesDetails : IdentityUser
    {
        public long Employeerollno { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDepartment { get; set; }
        
    }
}
