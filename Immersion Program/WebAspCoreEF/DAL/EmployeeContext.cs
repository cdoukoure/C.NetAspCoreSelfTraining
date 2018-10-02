using Microsoft.EntityFrameworkCore;
using WebAspCoreEF.Models;
// using DbContext = System.Data.Entity.DbContext;

namespace WebAspCoreEF.DAL
{
    public class EmployeeContext : DbContext
    {


        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> Departments { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
