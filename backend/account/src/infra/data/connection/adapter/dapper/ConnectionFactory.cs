using Amamovies.Account.Infra.Data;
using AmaMovies.Account.Infra.Database.Adapter;
using Microsoft.Extensions.Configuration;

namespace AmaMovies.Account.Infra.Data;

public class ConnectionFactory : IConnectionFactory
{
    private readonly IConfiguration _configuration;

    public ConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IConnection CreateConnection(ConnectionProviderType providerType)
    {
        return providerType switch
        {
            ConnectionProviderType.PostgreDapper =>
                new PostgreConnectionAdapter(_configuration.GetConnectionString("PostgreSQL")),

            ConnectionProviderType.SqliteDapper =>
                new SqLiteConnectionAdapter(_configuration.GetConnectionString("SQLite")),

            _ => throw new NotImplementedException("Provider type não suportado para Dapper.")
        };
    }
}