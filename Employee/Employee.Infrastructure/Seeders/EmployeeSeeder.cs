using Bogus;
using Employee.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Infrastructure.Seeders;

using EmployeeEntity = Entities.Employee;

public static class EmployeeSeeder
{
    public static void AddEmployees(this IServiceCollection services)
    {
        using var serviceScope = services.BuildServiceProvider().CreateScope();
        using var context = serviceScope.ServiceProvider.GetRequiredService<EmployeeDbContext>();

        _ = context.Database.EnsureDeleted();
        _ = context.Database.EnsureCreated();

        var employees = new Faker<EmployeeEntity>()
            .RuleFor(x => x.EmployeeLastName, f => f.Person.LastName)
            .RuleFor(x => x.EmployeeFirstName, f => f.Person.FirstName)
            .RuleFor(x => x.EmployeePhone, f => f.Phone.PhoneNumber("(###) ###-####"))
            .RuleFor(x => x.EmployeeZip, f => f.Address.ZipCode("#####"))
            .RuleFor(x => x.HireDate, f => f.Date.Past().Date)
            .Generate(10);

        context.Employees.AddRange(employees);
        context.SaveChanges();   
    }
}
