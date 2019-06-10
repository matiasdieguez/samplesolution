using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ProjectName.Common.Crypto
{
        public static class Crypto
    {
        private const string Key = "27dflkTC393djgdmasg89302i7426ug2";
        private const string IV = "DaUnxtem8.33tM52";

        public static byte[] GetKeyBytes()
        {
            return Encoding.ASCII.GetBytes(Key);
        }

        public static string Hash(string input)
        {
            var sha = SHA256.Create();
            byte[] hashValue;
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(input)))
                hashValue = sha.ComputeHash(stream);

            return Convert.ToBase64String(hashValue);
        }

        public static bool CompareHash(string hash, string plain)
        {
            var hashValue = Hash(plain);
            return hash == hashValue;
        }

        public static string Encrypt(string plainText)
        {
            byte[] key = Encoding.ASCII.GetBytes(Key);
            byte[] iv = Encoding.ASCII.GetBytes(IV);

            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string cipherText)
        {
            byte[] key = Encoding.ASCII.GetBytes(Key);
            byte[] iv = Encoding.ASCII.GetBytes(IV);

            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    plaintext = srDecrypt.ReadToEnd();
            }
            return plaintext;
        }
    }
}