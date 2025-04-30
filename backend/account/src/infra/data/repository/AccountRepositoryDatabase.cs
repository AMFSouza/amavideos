using AmaMovies.Account.Application.Repositories;
using AmaMovies.Account.Domain.Entities;
using Npgsql;
using System.Threading.Tasks;
using AmaMovies.Account.Infra.Database;
namespace AmaMovies.Account.Infra.Database;
public class AccountRepositoryDatabase : IAccountRepository
{
    private readonly IContext _context;
    private readonly IConnection<NpgsqlCommand> _connection;

    public AccountRepositoryDatabase(IContext context, IConnection<NpgsqlCommand> connnection)
    {
        _context = context;
        _context.SetConnection(connnection);
    }
    
    public async Task Save(UserAccount account)
    {
        await _context.UserAccounts.AddAsync(account);
        await _context.SaveChangesAsync();
    }

    public async Task<UserAccount> GetByEmail(string email)
    {
        return await _context.UserAccounts.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<UserAccount> GetById(string accountId)
    {
        return await _context.UserAccounts.FirstOrDefaultAsync(x => x.AccountId == accountId);
    }
}