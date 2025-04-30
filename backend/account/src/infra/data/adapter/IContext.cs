using System.Collections.Generic;
using AmaMovies.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace AmaMovies.Account.Infra.Database;
public interface IContext
{
    Task SaveChangesAsync();
    void SetConnection(ICollection<NpgsqlCommand> connection);
    DbSet<UserAccount> UserAccounts { get; }
}