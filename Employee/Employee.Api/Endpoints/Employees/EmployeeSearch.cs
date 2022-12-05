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
            _ = app.MapPost("/api/employees/search",
                    async ([FromServices] IMediator mediator,
                           [FromBody] EmployeeSearchQuery request) =>
                        Results.Ok(await mediator.Send(request)))
                .WithTags("Employees")
                .WithMetadata(new SwaggerOperationAttribute("Get employees coincidences by Firstnames or Lastnames from DB", "\n    GET /Employees/Search"))
                .Produces<EmployeeResponseDto>(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json);

            return app;
        }
    }
}
