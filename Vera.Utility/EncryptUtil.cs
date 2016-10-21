using System;
using System.Security.Cryptography;

namespace Vera.Utility
{
    public class EncryptUtil
    {
        /// <summary>
        /// Create string sha256 
        /// </summary>
        /// <param name="hashString"></param>
        /// <returns></returns>
        public static string CreateSHA256HashString(string password)
        {
            byte[] hashByte = System.Text.Encoding.UTF8.GetBytes(password);
            SHA256 mySHA256 = SHA256Managed.Create();
            return Convert.ToBase64String(mySHA256.ComputeHash(hashByte));
        }

        /// <summary>
        /// Create random salt
        /// </summary>
        /// <param name="saltByteCount">36</param>
        /// <returns></returns>
        public static string GetRandomSalt(int saltByteCount)
        {
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] saltByte = new byte[saltByteCount];
            csprng.GetBytes(saltByte);
            return Convert.ToBase64String(saltByte);
        }
    }
}
