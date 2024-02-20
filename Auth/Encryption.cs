using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Anarchy.Auth
{
    internal class Encryption
    {
        public static string APIService(string value)
        {
            string @string;
            @string = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
            return Encryption.EncryptString(value, SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string)), Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT))));
        }

        public static string EncryptService(string value)
        {
            string @string;
            @string = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
            return Encryption.EncryptString(value, SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string)), Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)))) + Security.Obfuscate(int.Parse(OnProgramStart.AID.Substring(0, 2)));
        }

        public static string DecryptService(string value)
        {
            string @string;
            @string = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
            return Encryption.DecryptString(value, SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string)), Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT))));
        }

        public static string EncryptString(string plainText, byte[] key, byte[] iv)
        {
            Aes aes;
            aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Key = key;
            aes.IV = iv;
            MemoryStream memoryStream;
            memoryStream = new MemoryStream();
            CryptoStream cryptoStream;
            cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            byte[] bytes;
            bytes = Encoding.ASCII.GetBytes(plainText);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] array;
            array = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(array, 0, array.Length);
        }

        public static string DecryptString(string cipherText, byte[] key, byte[] iv)
        {
            Aes aes;
            aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Key = key;
            aes.IV = iv;
            MemoryStream memoryStream;
            memoryStream = new MemoryStream();
            CryptoStream cryptoStream;
            cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
            string empty;
            empty = string.Empty;
            try
            {
                byte[] array;
                array = Convert.FromBase64String(cipherText);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                byte[] array2;
                array2 = memoryStream.ToArray();
                return Encoding.ASCII.GetString(array2, 0, array2.Length);
            }
            finally
            {
                memoryStream.Close();
                cryptoStream.Close();
            }
        }

        public static string Decode(string text)
        {
            text = text.Replace('_', '/').Replace('-', '+');
            switch (text.Length % 4)
            {
                case 3:
                    text += "=";
                    break;
                case 2:
                    text += "==";
                    break;
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(text));
        }
    }
}
