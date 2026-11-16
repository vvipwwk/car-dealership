using System;
using System.Globalization;
using System.Security.Cryptography;

namespace CarDealership
{
    public static class PasswordHasher
    {
        private const int Iterations = 120000;
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const string FormatPrefix = "pbkdf2-sha256";

        public static string Hash(string password)
        {
            if (password == null) throw new ArgumentNullException("password");

            byte[] salt = new byte[SaltSize];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
                random.GetBytes(salt);

            byte[] hash;
            using (Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                hash = deriveBytes.GetBytes(HashSize);

            return FormatPrefix + "$" + Iterations.ToString(CultureInfo.InvariantCulture) + "$" +
                Convert.ToBase64String(salt) + "$" + Convert.ToBase64String(hash);
        }

        public static bool Verify(string storedPassword, string suppliedPassword, out bool needsUpgrade)
        {
            needsUpgrade = false;
            if (storedPassword == null || suppliedPassword == null) return false;

            string[] parts = storedPassword.Split('$');
            if (parts.Length != 4 || !String.Equals(parts[0], FormatPrefix, StringComparison.Ordinal))
            {
                needsUpgrade = true;
                return ConstantTimeEquals(storedPassword, suppliedPassword);
            }

            int iterations;
            byte[] salt;
            byte[] expectedHash;
            try
            {
                iterations = Int32.Parse(parts[1], CultureInfo.InvariantCulture);
                salt = Convert.FromBase64String(parts[2]);
                expectedHash = Convert.FromBase64String(parts[3]);
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }

            if (iterations < 10000 || iterations > 1000000 || salt.Length < 16 || expectedHash.Length != HashSize)
                return false;

            byte[] actualHash;
            using (Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(suppliedPassword, salt, iterations, HashAlgorithmName.SHA256))
                actualHash = deriveBytes.GetBytes(HashSize);

            bool valid = ConstantTimeEquals(expectedHash, actualHash);
            needsUpgrade = valid && iterations < Iterations;
            return valid;
        }

        private static bool ConstantTimeEquals(string left, string right)
        {
            if (left == null || right == null) return false;

            int difference = left.Length ^ right.Length;
            int length = Math.Min(left.Length, right.Length);
            for (int i = 0; i < length; i++)
                difference |= left[i] ^ right[i];
            return difference == 0;
        }

        private static bool ConstantTimeEquals(byte[] left, byte[] right)
        {
            if (left == null || right == null || left.Length != right.Length) return false;

            int difference = 0;
            for (int i = 0; i < left.Length; i++)
                difference |= left[i] ^ right[i];
            return difference == 0;
        }
    }
}
