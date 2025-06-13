using System.Threading.Tasks;
namespace AmaMovies.Account.Application.UseCases;

public interface IUseCase
{
    Task<object> ExecuteAsync(object input);
}