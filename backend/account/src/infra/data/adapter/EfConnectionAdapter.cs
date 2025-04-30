using System.Threading.Tasks;
using AmaMovies.Account.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AmaMovies.Account.Infra.Data.Adapter;
public class EfConnectionAdapter : IConnection
{
    private readonly DbContext _dbContext;

    public EfConnectionAdapter(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Método QueryAsync usando consultas SQL dinâmicas
    public async Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters = null) where T : class
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentException("Query cannot be null or empty.");
        }

        //return await _dbContext.Set<T>().FromSqlInterpolated($"{query}").ToListAsync();
        //return await _dbContext.Set<T>().FromSqlInterpolated(query).ToListAsync();
    }

    // Método ExecuteAsync para persistência
    public async Task<int> ExecuteAsync(string query, object? parameters = null)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentException("Query cannot be null or empty.");
        }

        // Dependendo do uso, você pode implementar SQL bruto aqui.
        // Neste caso, mantemos SaveChanges para salvar alterações rastreadas pelo EF.
        return await _dbContext.SaveChangesAsync();
    }
}