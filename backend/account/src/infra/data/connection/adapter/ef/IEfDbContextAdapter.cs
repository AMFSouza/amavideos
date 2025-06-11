using Microsoft.EntityFrameworkCore;

namespace AmaMovies.Account.Infra.Data.Adapter;

public interface IEfDbContextAdapter
{
    DbContext GetDbContext(); 
}