using FluentAssertions;
using AmaMovies.Account.Infra.Data;
using AmaMovies.Account.Infra.Database;
using AmaMovies.Account.Application.UseCases;

namespace Account.Integ.Test;

public class AccountTest
{
    /*
    var adminStrategy = new SignupStrategy(new SignupAdmin(mockRepo.Object, mockMailer.Object));
    var customerStrategy = new SignupStrategy(new SignupCustomer(mockRepo.Object, mockMailer.Object));

    var adminResult = await adminStrategy.ExecuteStrategyAsync(new SignupAdminInput("John", "Doe", "admin@email.com", "123456", "password123"));
    var customerResult = await customerStrategy.ExecuteStrategyAsync(new SignupCustomerInput("Jane", "Smith", "customer@email.com", "789012", "password456"));
    */
    private readonly IConnection connection;
    private readonly AccountRepository accountRepository;
    private readonly ISignupStrategy signupAdmin;
    private readonly ISignupStrategy signupCustomer;
 
    //private readonly GetAccount getAccount;

    public AccountTest()
    {
        connection = new SqLiteConnectionAdapter();
        accountRepository = new AccountRepository(connection);
        signupAdmin = new SignupStrategy(new SignupAdmin(accountRepository));
        //getAccount = new GetAccount(accountRepository);

    }

    [Fact(DisplayName=nameof(should_signup_admin_account))]
    [Trait("Integration-Application", "Signup - Use Case")]
    public async Task should_signup_admin_account()
    {
        var input = new {
            Email = "user@gmail.com",
            Role = "user"
        };
        //signup = new Signup(input.Email, input.Role);
        var output = await signupAdmin.Execute(input);
        var account = await getAccount.Execute(output.accountId);
        account.accountId.Should().BeDefined();
        //account.Name
    }
}

