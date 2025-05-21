using System.Threading.Tasks;
namespace AmaMovies.Account.Application.UseCases;

public interface IUseCase<TInput, TOutput>
{
    Task<TOutput> ExecuteAsync(TInput input);
}