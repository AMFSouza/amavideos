namespace AmaMovies.Account.Infra.Data.Connection;
public interface IConnectionFactory
{
    IConnection CreateConnection(ConnectionProviderType providerType);
}