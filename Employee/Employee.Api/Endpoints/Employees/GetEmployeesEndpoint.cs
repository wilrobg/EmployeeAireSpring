using Employee.Application.Employees.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Employee.Api.Endpoints.Employees;

public static class GetEmployeesEndpoint
{
    public static WebApplication MapGetEmployeesEndpoint(this WebApplication app)
    {
        _ = app.MapGet("/api/employees",
                async ([FromServices] IMediator mediator) =>
                    Results.Ok(await mediator.Send(new GetEmployeesQuery())))
            .WithTags("Employees")
            .WithMetadata(new SwaggerOperationAttribute("Get all employees from DB", "\n    GET /Employees"))
            .Produces<IEnumerable<EmployeeResponseDto>>(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json);

        return app;
    }
}
