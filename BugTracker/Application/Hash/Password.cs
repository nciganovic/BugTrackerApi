using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hash
{
    public static class Password
    {
        public static HashSalt GenerateSaltedHash(int size, string password)
        {
            var saltedBytes = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltedBytes);
            var salt = Convert.ToBase64String(saltedBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltedBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            HashSalt hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt) {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DerivedBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DerivedBytes.GetBytes(256)) == storedHash;
        }
    }
}
