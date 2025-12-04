using Microsoft.EntityFrameworkCore;
using LearningCoreAPI.Model;
namespace LearningCoreAPI.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) :base(options)
        {

        }   
        public DbSet<TestEFfile> TestlearnEF { get; set;}
        public DbSet<StudentData> DStudentList { get; set;}
        public DbSet<Employeedatas> EmpDetails_data { get; set; }
    }
}
