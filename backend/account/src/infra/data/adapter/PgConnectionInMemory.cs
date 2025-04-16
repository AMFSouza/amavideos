using AmaMovies.Account.Infra.Database;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmaMovies.Account.Infra.Database;

public class PgConnectionInMemory : IConnection<NpgsqlCommand>
{
    private readonly Dictionary<string, List<NpgsqlCommand>> _database = new();

    public async Task<NpgsqlCommand> Query(string statement, NpgsqlCommand data)
    {
        if (!_database.ContainsKey(statement))
        {
            _database[statement] = new List<NpgsqlCommand>();
        }
        _database[statement].Add(data);
        await Task.CompletedTask;
        return data;
    }

    public async Task CloseAsync()
    {
        _database.Clear();
        await Task.CompletedTask;
    }
}