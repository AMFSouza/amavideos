
using AmaMovies.Account.Application.Repositories;
using AmaMovies.Account.Domain.Entities;
using AmaMovies.Account.Infra.Gateways;

namespace AmaMovies.Account.Application.UseCases;
public class SignupCustomer : IUseCase
{
    private readonly IAccountRepository _accountRepository;
    private readonly MailerGateway mailerGateway;

    public SignupCustomer(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
        mailerGateway = new MailerGateway();
    }

    public async Task<object> ExecuteAsync(object input)
    {
        if (input is not SignupCustomerInput signupInput) throw new ArgumentException("Invalid input type");
        var existingAccount = await _accountRepository.GetByEmail(signupInput.Email) ?? throw new Exception("Conta não existe"); 
        if (existingAccount != null) throw new Exception("Conta já existe");
        if (input == null) throw new Exception("Senha não pode ser nula");
        var account = UserAccount.Create(signupInput.Email, signupInput.FirstName, signupInput.LastName, signupInput.Password, signupInput.VerificationCode);
        await mailerGateway.Send(signupInput.Email, "Confirmação de cadastro", $"Seu código de verificação é: {signupInput.VerificationCode}");
        await _accountRepository.Save(account); 
        return new SignupCustomerOutput(account.GetId());        
    }
}


// Definições dos inputs e outputs
public record SignupCustomerInput(string FirstName, string LastName, string Email, string VerificationCode, string Password);
public record SignupCustomerOutput(string AccountId);



     