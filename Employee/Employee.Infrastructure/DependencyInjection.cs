using Employee.Application.Common.Repositories;
using Employee.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IDapperRepository, DapperRepository>();

        return services;
    }
}
