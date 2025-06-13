using Npgsql;

namespace AmaMovies.Account.Infra.Data.Adapter;

public class PostgreConnectionDapperAdapter : DapperAdapter
{
public PostgreConnectionDapperAdapter(string connectionString)
: base(new NpgsqlConnection(connectionString)) { }
}