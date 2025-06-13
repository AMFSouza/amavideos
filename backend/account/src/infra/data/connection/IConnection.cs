namespace AmaMovies.Account.Infra.Data.Connection;
public interface IConnection
{
    Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters = null) where T : class;
    Task<int> ExecuteAsync(string query, object? parameters = null);
}