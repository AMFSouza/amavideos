using Microsoft.EntityFrameworkCore;
using AmaMovies.Account.Domain.Entities;

namespace AmaMovies.Account.Infra.Data.Context;

public class AccountDbContext : DbContext
{
    public DbSet<UserAccount> Accounts { get; set; }

    public AccountDbContext(DbContextOptions<AccountDbContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserAccount>().ToTable("UserAccounts");
        modelBuilder.Entity<UserAccount>().HasKey(u => u.Id);
    }
}
