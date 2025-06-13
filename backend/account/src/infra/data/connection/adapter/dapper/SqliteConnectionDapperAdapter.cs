using Microsoft.Data.Sqlite;

namespace AmaMovies.Account.Infra.Data.Adapter;

public class SqliteConnectionDapperAdapter : DapperAdapter
{
    public SqliteConnectionDapperAdapter(string connectionString) 
        : base(new SqliteConnection(connectionString)) { }
}