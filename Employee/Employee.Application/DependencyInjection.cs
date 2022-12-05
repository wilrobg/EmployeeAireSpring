using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Employee.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Using CQRS pattern with MediatR
        _ = services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
