using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuizMania1.Common
{
    public class RandomNumber
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string ComputeSHA256(string secret)
        {
            try
            {
                var sha256 = SHA256.Create();
                var secretBytes = Encoding.UTF8.GetBytes(secret);
                var secretHash = sha256.ComputeHash(secretBytes);
                return Convert.ToHexString(secretHash);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
