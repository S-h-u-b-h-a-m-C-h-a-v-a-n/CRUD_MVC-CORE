using EmployeData.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace EmployeData.DAL
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }  

    }
}
