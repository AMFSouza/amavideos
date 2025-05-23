namespace AmaMovies.Account.Domain.Entities;

public interface IPassword
{
    string Value { get; }
    string Salt { get; }
    bool Validate(string value);
}