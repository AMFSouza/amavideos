using System.Threading.Tasks;
using FluentAssertions;         
using Xunit;
using AmaMovies.Account.Application.UseCases;
using AmaMovies.Account.Domain.Entities;
using AmaMovies.Account.Application.Repositories;
namespace Account.Integ.Test;

public class AccountTest
{
    private readonly IConnection connection;
    private readonly ISignupStrategy adminSignup = new AdminSignupStrategy();
    private readonly ISignupStrategy customerSignup = new CustomerSignupStrategy();
    private readonly AccountRepository accountRepository;
    private readonly GetAccount getAccount;

    public AccountTest() 
    {
        connection = new PgPromiseAdapter();
        accountRepository = new AccountRepository(connection);
        signup = new Signup(accountRepository);
        getAccount = new GetAccount(accountRepository);

    }

    [Fact(DisplayName=nameof(should_signup_new_adminuser))]
    [Trait("Integration-Application", "Signup - Use Case")]
    public async Task should_signup_new_adminuser()
    {
        var input = new {
            Email = "user@gmail.com",
            Role = "user"
        };
        //signup = new Signup(input.Email, input.Role);
        output = signup.Execute(input);
        account = await getAccount.Execute(output.accountId);
        account.accountId.Should().BeDefined();
        //account.Name
    }
}

