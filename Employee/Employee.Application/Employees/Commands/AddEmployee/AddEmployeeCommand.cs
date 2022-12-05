using Employee.Application.Common.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Employee.Application.Employees.Commands.AddEmployee;

public class AddEmployeeCommand : IRequest
{
    public string? EmployeeLastName { get; set; }
    public string? EmployeeFirstName { get; set; }
    public string? EmployeePhone { get; set; }
    public string? EmployeeZip { get; set; }
    public DateTime? HireDate { get; set; }
}

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand>
{
    private readonly IDapperRepository _repository;
	public AddEmployeeCommandHandler(IDapperRepository repository)
	{
        _repository = repository;
    }

    public async Task<Unit> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        const string query = @"Insert into Employees(EmployeeLastName, EmployeeFirstName, EmployeePhone, EmployeeZip, HireDate)
                                values(@EmployeeLastName, @EmployeeFirstName, @EmployeePhone, @EmployeeZip, @HireDate)";

        await _repository.ExecuteAsync(query, request);

        return Unit.Value;
    }
}
