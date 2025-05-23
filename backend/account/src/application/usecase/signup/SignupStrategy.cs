namespace AmaMovies.Account.Application.UseCases;

public class SignupStrategy : ISignupStrategy
{
    private readonly IUseCase _usecase;
    public SignupStrategy(IUseCase useCase)
    {
        _usecase = useCase;
    }
 
    public async Task<object> ExecuteSignupAsync(object input)
    {
       return await _usecase.ExecuteAsync(input);

    }
}

   
 
