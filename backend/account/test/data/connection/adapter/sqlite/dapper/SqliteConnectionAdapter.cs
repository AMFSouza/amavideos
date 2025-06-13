namespace AmaMovies.Account.Test.Data;

public class SqliteConnectionAdapter : BaseConnectionDapperAdapter
{
    public SqliteConnectionAdapter(string connectionString)
    : base(new SqliteConnection(connectionString)) { }
}