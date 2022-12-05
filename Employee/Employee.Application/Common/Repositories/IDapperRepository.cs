namespace Employee.Application.Common.Repositories;

public interface IDapperRepository
{
    Task<IEnumerable<T>> GetAsync<T>(string sql, object? parameters = null);
    Task<T> FirstOrDefaultAsync<T>(string sql, object? parameters = null);
}
