using AmaMovies.Account.Infra.Database;
using Npgsql;
using System.Threading.Tasks;

namespace AmaMovies.Account.Infra.Database;

public class PgConnectionAdapter : IConnection<NpgsqlCommand>
{
    private readonly NpgsqlConnection _connection;

    public PgConnectionAdapter(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
        _connection.Open();
    }

    public async Task<NpgsqlCommand> Query(string statement, NpgsqlCommand data)
    {
        using var command = new NpgsqlCommand(statement, _connection);
        foreach (NpgsqlParameter param in data.Parameters)
        {
            command.Parameters.Add(param);
        }
        await command.ExecuteNonQueryAsync();
        return command;
    }

    public async Task CloseAsync()
    {
        await _connection.CloseAsync();
    }
}