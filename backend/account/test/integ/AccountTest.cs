namespace Account.Integ.Test;

public class AccountTest
{
    private readonly Connection connection;
    private readonly Signup signup;
    private readonly AccountRepository accountRepository;
    private readonly GetAccount getAccount;

    public AccountTest() 
    {
        connection = new PgPromiseAdapter();
        accountRepository = new AccountRepository(connection);
        signup = new Signup(accountRepository);
        getAccount = new GetAccount(accountRepository);

    }

    [Fact(DisplayName=nameof(should_signup_new_user))]
    [Trait("Integration-Application", "Signup - Use Case")]
    public async Task should_signup_new_user()
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

