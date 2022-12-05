using Employee.Application.Employees.Queries.EmployeeSearch;
using Employee.Application.Employees.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Employee.Api.Endpoints.Employees
{
    public static class EmployeeSearch
    {
        public static WebApplication MapEmployeeSearch(this WebApplication app)
        {
            _ = app.MapGet("/api/employees/search", async (
                        [FromServices] IMediator mediator,
                        string? firstName, 
                        string? lastName) =>
                        Results.Ok(await mediator.Send(new EmployeeSearchQuery { LastName = lastName , FirstName = firstName})))
                .AddEndpointFilter(async (context, next) => 
                {
                    var firstName = context.GetArgument<string?>(1);
                    var lastName = context.GetArgument<string?>(2);

                    if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                        return Results.BadRequest("firstName and lastName can not be empty");

                    return await next(context);
                })
                .WithTags("Employees")
                .WithMetadata(new SwaggerOperationAttribute("Get employees coincidences by Firstnames or Lastnames from DB", "\n    GET /Employees/Search"))
                .Produces<EmployeeResponseDto>(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json);

            return app;
        }
    }
}
