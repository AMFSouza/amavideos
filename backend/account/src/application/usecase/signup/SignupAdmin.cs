using AmaMovies.Account.Application.Repositories;
using AmaMovies.Account.Infra.Gateways;
using AmaMovies.Account.Domain.Entities;

namespace AmaMovies.Account.Application.UseCases;
public class SignupAdmin : IUseCase
{
    private readonly IAccountRepository _accountRepository;
    private readonly MailerGateway mailerGateway;

    public SignupAdmin(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
        mailerGateway = new MailerGateway();
    }

    public async Task<object> ExecuteAsync(object input)
    {
        if (input is not SignupAdminInput signupInout) throw new ArgumentException("Invalid input type");
        var existingAccount = await _accountRepository.GetByEmail(signupInout.Email) ?? throw new Exception("Conta não existe"); 
        if (existingAccount != null) throw new Exception("Conta já existe");
        if (input == null) throw new Exception("Senha não pode ser nula");
        var account = UserAccount.Create(signupInout.Email, signupInout.FirstName, signupInout.LastName, signupInout.Password, signupInout.VerificationCode);
        await mailerGateway.Send(signupInout.Email, "Confirmação de cadastro", $"Seu código de verificação é: {signupInout.VerificationCode}");
        await _accountRepository.Save(account); 
        return new SignupAdminOutput(account.GetId());        
    }

}

public record SignupAdminInput(string FirstName, string LastName, string Email, string VerificationCode, string Password);
public record SignupAdminOutput(string AccountId);
