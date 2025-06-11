using AmaMovies.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Account.Integ.Test;

public class TestDbContext : DbContext
{
    public DbSet<UserAccount> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=:memory:");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserAccount>().ToTable("UserAccounts");
    }

    

}