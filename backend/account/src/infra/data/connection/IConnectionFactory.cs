using AmaMovies.Account.Infra.Data;

namespace Amamovies.Account.Infra.Data;
public interface IConnectionFactory
{
    IConnection CreateConnection(ConnectionProviderType providerType);
}