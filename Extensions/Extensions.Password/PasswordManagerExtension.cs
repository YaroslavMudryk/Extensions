using Microsoft.AspNetCore.Cryptography.KeyDerivation;
namespace Extensions.Password
{
    public static class PasswordManagerExtension
    {
        public static bool VerifyPasswordHash(this string password, string passwordHash)
        {
            return PasswordManager.VerifyPasswordHash(password, passwordHash);
        }

        public static string GeneratePasswordHash(this string password, KeyDerivationPrf prf = KeyDerivationPrf.HMACSHA256, int iterationCount = 10000, int saltSize = 16)
        {
            return PasswordManager.GeneratePasswordHash(password, prf, iterationCount, saltSize);
        }
    }
}