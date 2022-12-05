using Employee.Api.Endpoints.Employees;

namespace Employee.Api.Extensions;

public static class AplicationBuilder
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        //Mapping endpoints using Minimal APIS.
        //Segregate funcionality following SOLID principles
        _ = app.MapGetEmployeesEndpoint();
        _ = app.MapEmployeeSearchEndpoint();
        _ = app.MapCreateEmployeeEndpoint();
        _ = app.MapDeleteEmployeeEndpoint();

        return app;
    }
}
