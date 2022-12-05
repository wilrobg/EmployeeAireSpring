using Employee.Application.Common.Repositories;
using MediatR;

namespace Employee.Application.Employees.Queries.GetEmployees;

public class GetEmployeesQuery : IRequest<IEnumerable<EmployeeResponseDto>>
{
}

public class GetEmployeesRequestHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeResponseDto>>
{
    private readonly IDapperRepository _repository;
    public GetEmployeesRequestHandler(IDapperRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<EmployeeResponseDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        const string query = "SELECT * FROM Employees";

        return _repository.GetAsync<EmployeeResponseDto>(query);
    }
}
