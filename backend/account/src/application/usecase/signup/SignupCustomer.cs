
using AmaMovies.Account.Application.Repositories;
using AmaMovies.Account.Domain.Entities;
using AmaMovies.Account.Infra.Gateways;

namespace AmaMovies.Account.Application.UseCases;
public class SignupCustomer : ISignupStrategy<SignupCustomerInput, SignupCustomerOutput>
{
    private readonly IAccountRepository _accountRepository;
    private readonly MailerGateway mailerGateway;
    public SignupCustomer(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
        mailerGateway = new MailerGateway();
    }

    public async Task<SignupCustomerOutput> ExecuteAsync(SignupCustomerInput input)
    {
        var existingAccount = await _accountRepository.GetByEmail(input.Email) ?? throw new Exception("Conta não existe"); 
        if (existingAccount != null) throw new Exception("Conta já existe");
        if (input == null) throw new Exception("Senha não pode ser nula");
        var account = UserAccount.Create(input.Email, input.FirstName, input.LastName, input.Password, input.VerificationCode);
        await mailerGateway.Send(input.Email, "Confirmação de cadastro", $"Seu código de verificação é: {input.VerificationCode}");
        await _accountRepository.Save(account); 
        return new SignupCustomerOutput(account.GetId());
    }
}

// Definições dos inputs e outputs
public record SignupCustomerInput(string FirstName, string LastName, string Email, string VerificationCode, string Password);
public record SignupCustomerOutput(string AccountId);



     