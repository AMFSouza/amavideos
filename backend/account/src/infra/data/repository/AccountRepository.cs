using AmaMovies.Account.Application.Repositories;
using AmaMovies.Account.Domain.Entities;
using AmaMovies.Account.Infra.Data.Connection;

namespace AmaMovies.Account.Infra.Database;

public class AccountRepository : IAccountRepository
{
    private readonly IConnection _connection;

    public AccountRepository(IConnection connection)
    {
        _connection = connection;
    }

    public async Task Save(UserAccount account)
    {
        string query = "INSERT INTO UserAccounts (Id, Name, Email) VALUES (@Id, @Name, @Email)";
        var parameters = new { account.Id, account.Name, account.Email };
        await _connection.ExecuteAsync(query, parameters);
    }

    public async Task<UserAccount> GetByEmail(string email)
    {
        string query = "SELECT * FROM UserAccounts WHERE Email = @Email LIMIT 1";
        var parameters = new { Email = email };
        var result = await _connection.QueryAsync<UserAccount>(query, parameters);
        return result.FirstOrDefault();
    }

    public async Task<UserAccount> GetById(string accountId)
    {
        string query = "SELECT * FROM UserAccounts WHERE Id = @Id LIMIT 1";
        var parameters = new { Id = accountId };
        var result = await _connection.QueryAsync<UserAccount>(query, parameters);
        return result.FirstOrDefault();
    }
}
