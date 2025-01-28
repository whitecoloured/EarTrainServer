using System;
using System.Security.Cryptography;
using System.Text;

namespace EarTrain.Application.OtherServices
{
    public static class HashService
    {
        private static readonly MD5 md5= MD5.Create();
        public static string GetHashedPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            string hashedPassword=Convert.ToHexString(bytes);

            return hashedPassword;
        }
    }
}
