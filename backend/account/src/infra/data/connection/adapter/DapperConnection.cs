
using System.Data;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AmaMovies.Account.Infra.Data.Adapter;

public class DapperConnectionAdapter : IConnection
{
    private readonly IDbConnection _dbConnection;

    public DapperConnectionAdapter(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters = null)  where T : class
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentException("Query cannot be null or empty.");
        }

        return await _dbConnection.QueryAsync<T>(query, parameters);
    }

    public async Task<int> ExecuteAsync(string query, object? parameters = null)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentException("Query cannot be null or empty.");
        }

        return await _dbConnection.ExecuteAsync(query, parameters);
    }
}
