using System.Security.Cryptography;

namespace AmaMovies.Account.Domain.Entities
{
    public class PasswordPBKDF2 : IPassword
    {
        private const int SaltSize = 16; // 128 bit
        private const int KeySize = 32; // 256 bit
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;

        public string Value { get; private set; }
        public string Salt { get; private set; }

        public static PasswordPBKDF2 Create(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[SaltSize];
            rng.GetBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var hash = HashPassword(password, saltBytes);
            return new PasswordPBKDF2(hash, salt);
        }

        public static PasswordPBKDF2 Restore(string hash, string salt)
        {
            return new PasswordPBKDF2(hash, salt);
        }

        private PasswordPBKDF2(string value, string salt)
        {
            this.Value = value;
            this.Salt = salt;
        }

        public bool Validate(string password)
        {
            var saltBytes = Convert.FromBase64String(this.Salt);
            var hashToVerify = HashPassword(password, saltBytes);
            return this.Value == hashToVerify;
        }

        private static string HashPassword(string password, byte[] saltBytes)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithm);
            var key = pbkdf2.GetBytes(KeySize);
            return Convert.ToBase64String(key);
        }
    }
}