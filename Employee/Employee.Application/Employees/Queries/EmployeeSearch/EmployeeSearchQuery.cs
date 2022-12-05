using Employee.Application.Common.Repositories;
using MediatR;

namespace Employee.Application.Employees.Queries.EmployeeSearch;

public class EmployeeSearchQuery : IRequest<EmployeeSearchResponseDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class EmployeeSearchQueryHandler : IRequestHandler<EmployeeSearchQuery, EmployeeSearchResponseDto>
{
    private readonly IDapperRepository _repository;
    public EmployeeSearchQueryHandler(IDapperRepository repository)
    {
        _repository = repository;
    }

    public Task<EmployeeSearchResponseDto> Handle(EmployeeSearchQuery request, CancellationToken cancellationToken)
    {
        const string query = @"SELECT * FROM Employees
                                WHERE
                                EmployeeFirstName COLLATE SQL_Latin1_General_Cp1_CI_AI like CONCAT('%',@FirstName,'%')
                                OR
                                EmployeeLastName COLLATE SQL_Latin1_General_Cp1_CI_AI like CONCAT('%',@LastName,'%')";

        return _repository.FirstOrDefaultAsync<EmployeeSearchResponseDto>(query, request);
    }
}
