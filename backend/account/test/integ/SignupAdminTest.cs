using FluentAssertions;
using AmaMovies.Account.Infra.Database;
using AmaMovies.Account.Application.UseCases;
using AmaMovies.Account.Infra.Data.Connection;
using AmaMovies.Account.Infra.Data.Adapter;

namespace Account.Integ.Test;

public class SignupAdminTest
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
    private readonly GetAccount getAccount;
    private readonly TestDbContext _context;
    
    public SignupAdminTest()
    {
        _context = new TestDbContext();
        _context.Database.EnsureCreated(); // Ensure the in-memory database is created
        //connection = new SqliteConnectionDapperAdapter(_context).GetDbContext();
        connection = new SqliteConnectionDapperAdapter("Data Source=:memory:");
        accountRepository = new AccountRepository(connection);
        signupAdmin = new SignupStrategy(new SignupAdmin(accountRepository));
        getAccount = new GetAccount(accountRepository);

    }

    [Fact(DisplayName = nameof(should_signup_admin_account))]
    [Trait("Integration-Application", "Signup - Use Case")]
    public async Task should_signup_admin_account()
    {
        var input = new SignupAdminInput(
            "John",
            "Doe",
            "user@gmail.com",
            "123456",
            "password123"
        );
        var output = await signupAdmin.ExecuteSignupAsync(input);
        var accountId = ((SignupAdminOutput)output).AccountId;
        var account = await getAccount.ExecuteAsync(accountId);
        account.Should().NotBeNull();
        
        
    }
}

