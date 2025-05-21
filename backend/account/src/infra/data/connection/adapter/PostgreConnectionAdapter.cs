using Npgsql;
using Dapper;
using AmaMovies.Account.Infra.Data;

namespace AmaMovies.Account.Infra.Database.Adapter;

public class PostgreConnectionAdapter : IConnection
{
    private readonly NpgsqlConnection _connection;

    public PostgreConnectionAdapter(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
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


}