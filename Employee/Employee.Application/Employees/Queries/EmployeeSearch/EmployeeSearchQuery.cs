using Employee.Application.Common.Repositories;
using MediatR;
using System.Text;

namespace Employee.Application.Employees.Queries.EmployeeSearch;

public class EmployeeSearchQuery : IRequest<IEnumerable<EmployeeSearchResponseDto>>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

public class EmployeeSearchQueryHandler : IRequestHandler<EmployeeSearchQuery, IEnumerable<EmployeeSearchResponseDto>>
{
    private readonly IDapperRepository _repository;
    public EmployeeSearchQueryHandler(IDapperRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EmployeeSearchResponseDto>> Handle(EmployeeSearchQuery request, CancellationToken cancellationToken)
    {
        StringBuilder queryBuilder = new("SELECT * FROM Employees\n");

        if (!string.IsNullOrEmpty(request.FirstName) || !string.IsNullOrEmpty(request.LastName))
            queryBuilder.AppendLine("WHERE");

        if (!string.IsNullOrEmpty(request.FirstName))
            queryBuilder.AppendLine(@"EmployeeFirstName COLLATE SQL_Latin1_General_Cp1_CI_AI like CONCAT('%',@FirstName,'%')");

        if (!string.IsNullOrEmpty(request.FirstName) && !string.IsNullOrEmpty(request.LastName))
            queryBuilder.AppendLine("OR");

        if (!string.IsNullOrEmpty(request.LastName))
            queryBuilder.AppendLine(@"EmployeeLastName COLLATE SQL_Latin1_General_Cp1_CI_AI like CONCAT('%',@LastName,'%')");

        return await _repository.GetAsync<EmployeeSearchResponseDto>(queryBuilder.ToString(), request);
    }
}
