using LearningCoreAPI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearningCoreAPI.Data
{
    public class AppDbContextIdentity : IdentityDbContext<Bulk_EmployeesDetails>
    {
        public AppDbContextIdentity(DbContextOptions<AppDbContextIdentity>options):base(options)
        {

        }
    }
}
