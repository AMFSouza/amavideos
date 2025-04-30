using AmaMovies.Account.Infra.Database;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmaMovies.Account.Infra.Data.Adapter  ;

public class MemoryPgConnectionAdapter : IConnection
{
    private readonly Dictionary<string, List<object>> _dataStorage = new();

    public Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters = null) where T: class
    {
        // Simula consulta em memória
        if (_dataStorage.TryGetValue(typeof(T).Name, out var data))
        {
            return Task.FromResult(data.Cast<T>());
        }

        return Task.FromResult(Enumerable.Empty<T>());
    }

    public Task<int> ExecuteAsync(string query, object? parameters = null)
    {
        // Simula inserção/atualização em memória
        return Task.FromResult(1);
    }
}