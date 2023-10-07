using System;
using System.Security.Cryptography;
using System.Text;
using System.Reflection;

namespace MMRR_Tracker
{

    static class EncryptionUtility
    {
        public static object EncryptObjectStrings(object obj, string key)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    string originalValue = (string)property.GetValue(obj);
                    string encryptedValue = EncryptionUtility.Encrypt(originalValue, key);
                    property.SetValue(obj, encryptedValue);
                }
            }

            return obj;
        }

        public static string Encrypt(string input, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            using (var aesAlg = new AesManaged())
            {
                byte[] hashBytes = new SHA256Managed().ComputeHash(keyBytes);
                aesAlg.Key = hashBytes;
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string Decrypt(string input, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Convert.FromBase64String(input);

            using (var aesAlg = new AesManaged())
            {
                byte[] hashBytes = new SHA256Managed().ComputeHash(keyBytes);
                aesAlg.Key = hashBytes;
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }

}
