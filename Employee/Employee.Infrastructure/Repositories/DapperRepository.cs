using Dapper;
using Employee.Application.Common.Repositories;
using Employee.Infrastructure.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Employee.Infrastructure.Repositories;

public class DapperRepository : IDapperRepository
{
    private readonly ConnectionStrings _connectionStrings;
    public DapperRepository(IOptions<ConnectionStrings> connectionStrings)
    {
        _connectionStrings = connectionStrings.Value;
    }

    public Task<IEnumerable<T>> GetAsync<T>(string sql)
    {
        var connection = new SqlConnection(_connectionStrings.EmployeeDB);
        return connection.QueryAsync<T>(sql);
    }

    public Task<T> FirstOrDefaultAsync<T>(string sql)
    {
        var connection = new SqlConnection(_connectionStrings.EmployeeDB);
        return connection.QueryFirstOrDefaultAsync<T>(sql);
    }
    
}
