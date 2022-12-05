using Employee.Application.Employees.Commands.AddEmployee;
using Employee.Application.Employees.Commands.UpdateEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Employee.Web.Endpoints.Employees;

public static class UpdateEmployeeEndpoint
{
    public static WebApplication MapUpdateEmployeeEndpoint(this WebApplication app)
    {
        _ = app.MapPut("/api/employee", async (
                        [FromServices] IMediator mediator,
                        [FromBody] UpdateEmployeeCommand request) =>
        {
            await mediator.Send(request);
            return Results.Ok();
        })
            .WithTags("Employees")
            .WithMetadata(new SwaggerOperationAttribute("Update employees record", "\n    Post /Employee"))
            .Produces(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json);

        return app;
    }
}
