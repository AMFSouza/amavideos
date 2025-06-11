using AmaMovies.Account.Infra.Data.Adapter;
using Microsoft.EntityFrameworkCore;

namespace AmaMovies.Account.Infra.Data;

public class PostgreEfDbContextAdapter : IEfDbContextAdapter
{
    private readonly string _connectionString;

    public PostgreEfDbContextAdapter(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AccountDbContext>()
            .UseNpgsql(_connectionString)
            .Options;

        return new AccountDbContext(options);
    }

    DbContext IEfDbContextAdapter.GetDbContext()
    {
        throw new NotImplementedException();
    }
}