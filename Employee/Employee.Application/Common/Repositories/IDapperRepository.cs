namespace Employee.Application.Common.Repositories;

public interface IDapperRepository
{
    Task<IEnumerable<T>> GetAsync<T>(string sql);
    Task<T> FirstOrDefaultAsync<T>(string sql);
}
