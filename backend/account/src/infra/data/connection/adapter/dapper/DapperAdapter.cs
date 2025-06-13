using System.Data;
using Dapper;
using AmaMovies.Account.Infra.Data.Connection;

namespace AmaMovies.Account.Infra.Data.Adapter;

public abstract class DapperAdapter : IConnection
{
    protected readonly IDbConnection _connection;

    protected DapperAdapter(IDbConnection connection)
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