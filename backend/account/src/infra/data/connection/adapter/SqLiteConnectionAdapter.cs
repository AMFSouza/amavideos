using Dapper; // Importação necessária para QueryAsync<T> e ExecuteAsync
using AmaMovies.Account.Infra.Data;
using Microsoft.Data.Sqlite;
using System.Data;

namespace AmaMovies.Account.Infra.Database.Adapter;

public class SQLiteAdapter : IConnection
{
    private readonly SqliteConnection _connection;

    public SQLiteAdapter(string connectionString)
    {
        _connection = new SqliteConnection(connectionString);
        _connection.Open(); // Mantém conexão aberta enquanto o objeto existir
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters = null)
        where T : class
    {
        return await _connection.QueryAsync<T>(query, parameters, commandType: CommandType.Text);
    }

    public async Task<int> ExecuteAsync(string query, object? parameters = null)
    {
        return await _connection.ExecuteAsync(query, parameters);
    }

    public void Close()
    {
        _connection.Close(); // Fecha conexão corretamente para evitar leaks
    }
}