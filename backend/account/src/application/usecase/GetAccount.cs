using AmaMovies.Account.Application.Repositories;

namespace AmaMovies.Account.Application.UseCases;

public class GetAccount : IUseCase
{
    private readonly IAccountRepository _accountRepository;

    public GetAccount(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<object> ExecuteAsync(object input)
    {
        if (input is not string accountId)
        {
            throw new ArgumentException("Input must be a string representing the account ID.");
        }

        var account = await _accountRepository.GetById(accountId);
        return account ?? throw new KeyNotFoundException($"Account with ID {accountId} not found.");
    }
}