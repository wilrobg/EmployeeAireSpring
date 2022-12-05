using Employee.Application.Employees.Commands.AddEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Employee.Web.Endpoints.Employees;

public static class CreateEmployeeEndpoint
{
    public static WebApplication MapCreateEmployeeEndpoint(this WebApplication app)
    {
        _ = app.MapPost("/api/employee", async (
                        [FromServices] IMediator mediator,
                        [FromBody] AddEmployeeCommand request) =>
        {
            await mediator.Send(request);
            return Results.Ok();
        })
            .WithTags("Employees")
            .WithMetadata(new SwaggerOperationAttribute("Create employees record", "\n    Post /Employee"))
            .Produces(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json);

        return app;
    }
}
