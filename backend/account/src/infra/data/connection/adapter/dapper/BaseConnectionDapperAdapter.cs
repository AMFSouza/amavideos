using System.Data;
using Dapper;

namespace AmaMovies.Account.Infra.Data.Adapter;

public abstract class BaseConnectionDapperAdapter : IConnection
{
    protected readonly IDbConnection _connection;

    protected BaseConnectionDapperAdapter(IDbConnection connection)
    {
        _connection = connection;
        _connection.Open(); // Mantém conexão aberta
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters = null) where T : class
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentException("Query cannot be null or empty.");
        }

        return await _connection.QueryAsync<T>(query, parameters);
    }

    public async Task<int> ExecuteAsync(string query, object? parameters = null)
    {
        return await _connection.ExecuteAsync(query, parameters);
    }

    public void Close() => _connection.Close();
}