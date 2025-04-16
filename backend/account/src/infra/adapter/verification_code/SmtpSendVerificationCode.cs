namespace AmaMovies.Account.Application.UseCases.VerificationCode;
public class SmtpVerificationCodeSender : IVerificationCodeSender
{
    private readonly SmtpClient _smtpClient;

    public SmtpVerificationCodeSender(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient ?? throw new ArgumentNullException(nameof(smtpClient));
    }

    public async Task SendAsync(string email, string code)
    {
        var mailMessage = new MailMessage("noreply@amavideos.com", email)
        {
            Subject = "Seu Código de Verificação",
            Body = $"Seu código de verificação é: {code}",
            IsBodyHtml = false,
        };

        await _smtpClient.SendMailAsync(mailMessage);
    }
}
public record Input(string Email, Guid? UserId, string Purpose);
public record Output(string VerificationCode);
