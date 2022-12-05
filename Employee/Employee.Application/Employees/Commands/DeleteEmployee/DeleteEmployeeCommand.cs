using Employee.Application.Common.Repositories;
using MediatR;

namespace Employee.Application.Employees.Commands.DeleteEmployee;

public class DeleteEmployeeCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IDapperRepository _dapperRepository;
    public DeleteEmployeeCommandHandler(IDapperRepository dapperRepository)
    {
        _dapperRepository = dapperRepository;
    }
    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        const string query = @"Delete from Employees where Id = @Id";
        await _dapperRepository.ExecuteAsync(query, request);
        return Unit.Value;
    }
}
