using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MMRR_Tracker
{
	public class Program_encryptor
	{
		public static byte[] GenerateRandomKey()
		{
			// Create a new random key with the correct size (256 bits)
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.KeySize = 256;
				aesAlg.GenerateKey();
				return aesAlg.Key;
			}
		}

		public static void EncryptJsonFile(string sourceFilePath, string encryptedFilePath, byte[] encryptionKey)
		{
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = encryptionKey;
				aesAlg.IV = new byte[16]; // You can generate a random IV if needed

				using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
				using (FileStream encryptedStream = new FileStream(encryptedFilePath, FileMode.Create, FileAccess.Write))
				using (CryptoStream cryptoStream = new CryptoStream(encryptedStream, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
				{
					sourceStream.CopyTo(cryptoStream);
				}
			}
		}
	}
}