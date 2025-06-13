namespace AmaMovies.Account.Test.Data;

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
            .UseSqlite(_connectionString) // 🔹 Agora está aqui!
            .Options;

        var context = new AccountDbContext(options);
        context.Database.EnsureCreated();
        return context;
    }
}
