using System;
using System.Security.Cryptography;
using System.Text;

namespace MusicStore.Services
{
    public class Encryptor
    {
        public string MD5Hash(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                throw new ArgumentNullException();

            using var md5Encryption = MD5.Create();

            var hashBytes = md5Encryption.ComputeHash(Encoding.UTF8.GetBytes(msg));
            var hashString = BitConverter.ToString(hashBytes).Replace("-", "");

            return hashString;
        }

    }
}
