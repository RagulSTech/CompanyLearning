using LearningCoreAPI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LearningCoreAPI.Data
{
    public class AppDbContextIdentity : IdentityDbContext<Bulk_EmployeesDetails>
    {
        public AppDbContextIdentity()
        {

        }
    }
}
