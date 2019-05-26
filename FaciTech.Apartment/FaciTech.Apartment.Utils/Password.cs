using System;
using System.Security.Cryptography;
using System.Text;

namespace FaciTech.Apartment.Utils
{
    public static class Password
    {
        public static string Hash(this string password,string salt)
        {
            string saltedPassword = string.Concat(password, salt);
            MD5CryptoServiceProvider hasher = new MD5CryptoServiceProvider();
            string hashedPassword = "";

            var passwordBytes = Encoding.UTF8.GetBytes(saltedPassword);
            var hashedBytes = hasher.ComputeHash(passwordBytes);
            hasher.Clear();
            hashedPassword = Convert.ToBase64String(hashedBytes);

            return hashedPassword;
        }
        public static string GetSalt(int maximumSaltLength=10)
        {
            var saltBytes = new byte[maximumSaltLength];
            string salt = "";
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(saltBytes);
            }
            salt = BitConverter.ToString(saltBytes)
                .Replace("-","");
            return salt;
        }
    }
}
