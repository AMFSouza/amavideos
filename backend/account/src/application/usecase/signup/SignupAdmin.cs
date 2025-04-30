using AmaMovies.Account.Application.Repositories;
using AmaMovies.Account.Infra.Gateways;
using AmaMovies.Account.Domain.Entities;

namespace AmaMovies.Account.Application.UseCases;
public class SignupAdmin : ISignupStrategy<SignupAdminInput, SignupAdminOutput>
{
    private readonly IAccountRepository _accountRepository;
    private readonly MailerGateway mailerGateway;

    public SignupAdmin(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
        mailerGateway = new MailerGateway();
    }

    public async Task<SignupAdminOutput> ExecuteAsync(SignupAdminInput input)
    {
        var existingAccount = await _accountRepository.GetByEmail(input.Email);
        if (existingAccount != null) throw new Exception("Conta já existe");
        if (input.Password == null) throw new Exception("Senha não pode ser nula");
        var account = UserAccount.Create(input.Email, input.FirstName, input.LastName, input.Password, input.VerificationCode);
        await mailerGateway.Send(input.Email, "Confirmação de cadastro", $"Seu código de verificação é: {input.VerificationCode}");
        await _accountRepository.Save(account); 

        await _accountRepository.Save(account); 
        return new SignupAdminOutput(account.GetId());
      }
}

public record SignupAdminInput(string FirstName, string LastName, string Email, string VerificationCode, string Password);
public record SignupAdminOutput(string AccountId);
