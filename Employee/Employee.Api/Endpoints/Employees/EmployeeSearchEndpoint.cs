using Azure.Core;
using Employee.Application.Employees.Queries.EmployeeSearch;
using Employee.Application.Employees.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Employee.Api.Endpoints.Employees
{
    public static class EmployeeSearchEndpoint
    {
        public static WebApplication MapEmployeeSearchEndpoint(this WebApplication app)
        {
            _ = app.MapGet("/api/employees/search", async (
                        [FromServices] IMediator mediator,
                        [AsParameters] EmployeeSearchQuery request) =>
                        Results.Ok(await mediator.Send(request)))
                .AddEndpointFilter(async (context, next) => 
                {
                    var request = context.GetArgument<EmployeeSearchQuery>(1);

                    if (string.IsNullOrEmpty(request.FirstName) && string.IsNullOrEmpty(request.LastName))
                        return Results.BadRequest("firstName and lastName can not be empty");

                    return await next(context);
                })
                .WithTags("Employees")
                .WithMetadata(new SwaggerOperationAttribute("Get employees coincidences by Firstnames or Lastnames from DB", "\n    GET /Employees/Search"))
                .Produces<IEnumerable<EmployeeResponseDto>>(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json);

            return app;
        }
    }
}
