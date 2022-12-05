using Employee.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Infrastructure;

public static class DbContextSetup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<EmployeeDbContext>(options =>
        options.UseSqlServer(connectionString));
}
