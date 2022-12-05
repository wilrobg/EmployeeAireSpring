using Employee.Application.Employees.Queries.EmployeeSearch;
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
                        Results.Ok(await mediator.Send(new EmployeeSearchQuery { LastName = lastName, FirstName = firstName })))
                .WithTags("Employees")
                .WithMetadata(new SwaggerOperationAttribute("Get employees coincidences by Firstnames or Lastnames from DB", "\n    GET /Employees/Search"))
                .Produces<IEnumerable<EmployeeSearchResponseDto>>(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json);

            return app;
        }
    }
}
