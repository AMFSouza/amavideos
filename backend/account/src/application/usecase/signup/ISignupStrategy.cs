namespace AmaMovies.Account.Application.UseCases;
public interface ISignupStrategy
{
    Task<object> ExecuteSignupAsync(object input);
}
