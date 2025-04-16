using System;
using System.Security.Cryptography;
using System.Text;
using Account.Domain.Enum;
using Account.Domain.Vo;
using AmaMovies.Account.Domain.Entities.Password;
using AmaMovies.Account.Domain.Entity.Password;
using AmaMovies.Account.Domain.Enum;

namespace AmaMovies.Account.Domain.Entities;
public class UserAccount : IAggregateRoot
{
    private readonly string Id;
    private readonly Name Name;
    private readonly Email Email;
    public AccountType AccountType { get; private set; }
    public Status Status;
    public readonly string? VerificationCode;
    private readonly DateTime CreatedAt;
    private readonly DateTime UpdatedAt;
    private readonly IPassword Password;
    

    private UserAccount(string id, string firstName, string lastName, string email, string password,
        Status status, string verificationCode, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Name = new Name(firstName, lastName);
        Email = new Email(email);
        Password = PasswordPBKDF2.Create(password);
        Status = status;
        VerificationCode = verificationCode;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static UserAccount Create(string email, string firstName, string lastName, string password, string verificationCode)
    {
        Validate(email, password, verificationCode);

        var encryptedId = GenerateEncryptedUuid();
        var passwordPBKDF2 = PasswordPBKDF2.Create(password);
        var now = DateTime.UtcNow;

        return new UserAccount(encryptedId.ToString(), email, firstName, lastName, passwordPBKDF2.Value, Status.Active, verificationCode, now, now);
    }

    public static UserAccount Restore(string id, string email, string firstName, string lastName, PasswordPBKDF2 password,
        string status, string verificationCode, DateTime createdAt, DateTime updatedAt)
    {
        Validate(email, password.Value, verificationCode);

        return new UserAccount(id, email, firstName, lastName, password.Value, System.Enum.Parse<Status>(status), verificationCode, createdAt, updatedAt);
    }   

    private static string GenerateEncryptedUuid()
    {
        var guid = Guid.NewGuid().ToString();
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(guid));
        return Convert.ToBase64String(hash);
    }

    private static void Validate(string email, string password, string verificationCode)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("E-mail é obrigatório.");
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Senha é obrigatória.");
        if (string.IsNullOrWhiteSpace(verificationCode)) throw new ArgumentException("Código de verificação é obrigatório.");
    }

    public string GetId()
    {
        return Id;
    }
    public string GetEmail()
    {
        return Email.Value;
    }
    public string GetFirstName()
    {
        return Name.FirstName;
    }
    public string GetLastName()
    {
        return Name.LastName;
    }
    public string GetPassword()
    {
        return Password.Value;
    }
    public string GetVerificationCode()
    {
        return VerificationCode;
    }
    public string GetStatus()
    {
        return Status.ToString();
    }
    public string GetCreatedAt()
    {
        return CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss");
    }
    public string GetUpdatedAt()
    {
        return UpdatedAt.ToString("yyyy-MM-ddTHH:mm:ss");
    }
    public void SetStatus(Status status)
    {
        Status = status;
    }
}
     