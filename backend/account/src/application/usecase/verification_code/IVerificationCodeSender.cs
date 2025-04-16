namespace AmaMovies.Account.UseCases.VerificationCode;
public interface IVerificationCodeSender
{
    Task SendAsync(string email, string code);
}