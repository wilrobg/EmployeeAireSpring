using Employee.Application.Common.Repositories;
using MediatR;

namespace Employee.Application.Employees.Queries.GetById;

public class GetByIdCommand : IRequest<GetByIdResponseDto>
{
    public int Id { get; set; }
}

public class GetByIdCommandHandler : IRequestHandler<GetByIdCommand, GetByIdResponseDto>
{
    private readonly IDapperRepository _dapperRepository;
    public GetByIdCommandHandler(IDapperRepository dapperRepository)
    {
        _dapperRepository = dapperRepository;
    }

    public Task<GetByIdResponseDto> Handle(GetByIdCommand request, CancellationToken cancellationToken)
    {
        const string query = @"select * from Employees where Id = @Id";
        return _dapperRepository.FirstOrDefaultAsync<GetByIdResponseDto>(query, request);
    }
}
