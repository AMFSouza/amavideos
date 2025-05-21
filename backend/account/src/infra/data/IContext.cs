using System.Collections.Generic;
using AmaMovies.Account.Domain.Entities;
using AmaMovies.Account.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace AmaMovies.Account.Infra.Database;

public interface IContext
{
    Task SaveChangesAsync();
    void SetConnection(IConnection connection);
}