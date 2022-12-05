using Employee.Application.Common.Repositories;
using MediatR;

namespace Employee.Application.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommand : IRequest
{
    public int Id { get; set; }
    public string EmployeeLastName { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeePhone { get; set; }
    public string EmployeeZip { get; set; }
    public DateTime? HireDate { get; set; }
}

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IDapperRepository _dapperRepository;
    public UpdateEmployeeCommandHandler(IDapperRepository dapperRepository)
    {
        _dapperRepository= dapperRepository;
    }

    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        const string query = @"Update Employees SET 
                                EmployeeFirstName = @EmployeeFirstName,
                                EmployeeLastName = @EmployeeLastName,
                                EmployeePhone = @EmployeePhone,
                                EmployeeZip = @EmployeeZip,
                                HireDate = @HireDate
                                WHERE Id = @Id";

        await _dapperRepository.ExecuteAsync(query, request);

        return Unit.Value;
    }
}
