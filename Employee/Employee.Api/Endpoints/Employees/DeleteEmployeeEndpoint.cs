using Employee.Application.Employees.Commands.AddEmployee;
using Employee.Application.Employees.Commands.DeleteEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Employee.Api.Endpoints.Employees;

public static class DeleteEmployeeEndpoint
{
    public static WebApplication MapDeleteEmployeeEndpoint(this WebApplication app)
    {
        _ = app.MapDelete("/api/employee/{id:int}", async (
                        [FromServices] IMediator mediator,
                        int id) =>
        {
            await mediator.Send(new DeleteEmployeeCommand { Id = id });
            return Results.Ok();
        })
            .WithTags("Employees")
            .WithMetadata(new SwaggerOperationAttribute("Create employees record", "\n    Post /Employee"))
            .Produces(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json);

        return app;
    }
}
