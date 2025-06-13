using AmaMovies.Account.Infra.Data.Connection;

namespace AmaMovies.Account.Infra.Database;

public interface IContext
{
    Task SaveChangesAsync();
    void SetConnection(IConnection connection);
}