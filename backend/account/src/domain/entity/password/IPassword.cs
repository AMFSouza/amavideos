namespace AmaMovies.Account.Domain.Entity.Password;
public interface IPassword
{
    string Value { get; }
    string Salt { get; }
    bool Validate(string value);
}