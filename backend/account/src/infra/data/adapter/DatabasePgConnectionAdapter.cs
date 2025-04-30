using AmaMovies.Account.Infra.Database;
using AmaMovies.Account.Application.Repositories;
using Npgsql;
using System.Threading.Tasks;
using Dapper;
using AmaMovies.Account.Infra.Data;

namespace AmaMovies.Account.Infra.Database.Adapter;

public class DatabasePgConnectionAdapter : IConnection
{
    private readonly string _connectionString;

    public DatabasePgConnectionAdapter(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters = null) where T : class
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentException("Query cannot be null or empty.");
        }

        // Use Dapper to execute the query
    
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<T>(query, parameters);
    }

    public async Task<int> ExecuteAsync(string query, object? parameters = null)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return await connection.ExecuteAsync(query, parameters);
    }


}