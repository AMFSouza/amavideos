namespace AmaMovies.Account.Infra.Database;
public interface IConnection<TResult>
{
    Task<TResult> Query(string statement, TResult data);
    Task CloseAsync();
}