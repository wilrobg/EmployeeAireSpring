using Microsoft.EntityFrameworkCore;

using EmployeeEntity = Employee.Infrastructure.Entities.Employee;

namespace Employee.Infrastructure.Database;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<EmployeeEntity> Employees { get; set; }
}
