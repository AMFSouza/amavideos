using Npgsql;
using Dapper;
using AmaMovies.Account.Infra.Data;
using AmaMovies.Account.Infra.Data.Adapter;

namespace AmaMovies.Account.Infra.Database.Adapter;

public class PostgreConnectionAdapter : BaseConnectionDapperAdapter
{
public PostgreConnectionAdapter(string connectionString)
: base(new NpgsqlConnection(connectionString)) { }
}