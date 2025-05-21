using AmaMovies.Account.Domain.Entities;

namespace AmaMovies.Account.Application.Repositories;
public interface IAccountRepository
{
    Task Save(UserAccount account);
    Task<UserAccount> GetByEmail(string email);
    Task<UserAccount> GetById(string accountId);
}