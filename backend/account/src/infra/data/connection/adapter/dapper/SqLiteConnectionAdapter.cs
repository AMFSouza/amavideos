using Dapper; // Importação necessária para QueryAsync<T> e ExecuteAsync
using AmaMovies.Account.Infra.Data;
using Microsoft.Data.Sqlite;
using System.Data;
using AmaMovies.Account.Infra.Data.Adapter;

namespace AmaMovies.Account.Infra.Database.Adapter;

public class SqLiteConnectionAdapter : BaseConnectionDapperAdapter
{
    public SqLiteConnectionAdapter(string connectionString)
    : base(new SqliteConnection(connectionString)) { }
}