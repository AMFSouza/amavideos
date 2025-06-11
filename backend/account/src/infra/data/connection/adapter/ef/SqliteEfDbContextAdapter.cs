using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace AmaMovies.Account.Infra.Data.Adapter;

public class SqliteEfDbContextAdapter : IEfDbContextAdapter
{
     private readonly string _connectionString;

    public SqliteEfDbContextAdapter(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AccountDbContext>()
            .UseSqlite(_connectionString)
            .Options;

        var context = new AccountDbContext(options);
        context.Database.EnsureCreated(); // se estiver usando in-memory
        return context;
    }

}