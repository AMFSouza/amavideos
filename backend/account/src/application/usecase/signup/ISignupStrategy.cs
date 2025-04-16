namespace AmaMovies.Account.Application.UseCases;
public interface ISignupStrategy<TInput, TOutput> : IUseCase<TInput, TOutput>
    where TOutput : class // Você pode ajustar essa restrição conforme necessário.
{
    Task<TOutput> ExecuteAsync(TInput input);
}