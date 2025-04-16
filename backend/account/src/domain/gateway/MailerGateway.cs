namespace AmaMovies.Account.Infra.Gateways;
public class MailerGateway
{
    public MailerGateway()
    {
    }

    public async Task Send(string email, string subject, string message)
    {
        // Simulando uma operação assíncrona com Task.Delay
        await Task.Delay(500);
        Console.WriteLine($"Email enviado para {email} com o assunto {subject} e a mensagem: {message}");
    }
}