
using Microsoft.Extensions.Configuration;
using AmaMovies.Account.Infra.Data.Connection;
using AmaMovies.Account.Infra.Data.Adapter;

namespace AmaMovies.Account.Infra.Data;

public class ConnectionFactory : IConnectionFactory
{
    private readonly IConfiguration _configuration;

    public ConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IConnection CreateConnection(ConnectionProviderType providerType) => providerType switch
    {
        ConnectionProviderType.PostgreDapper =>
            new PostgreConnectionDapperAdapter(_configuration.GetConnectionString("PostgreSQL")),
        ConnectionProviderType.SqliteDapper =>
            new SqliteConnectionDapperAdapter(_configuration.GetConnectionString("Sqlite")),

        _ => throw new NotImplementedException("Provider type não suportado para Dapper.")
    };
}