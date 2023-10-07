using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;




namespace MMRR_Tracker
{
	public class Program_decryptor
	{


		public static string DecryptJsonFile(string encryptedFilePath, byte[] encryptionKey)
		{
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = encryptionKey;

				// Ensure the same IV is used for decryption
				aesAlg.IV = new byte[16]; // You should use the same IV used for encryption

				// Set the padding mode to PKCS7
				aesAlg.Padding = PaddingMode.PKCS7;

				using (FileStream encryptedStream = new FileStream(encryptedFilePath, FileMode.Open, FileAccess.Read))
				using (MemoryStream decryptedStream = new MemoryStream())
				using (CryptoStream cryptoStream = new CryptoStream(encryptedStream, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
				{
					cryptoStream.CopyTo(decryptedStream);
					byte[] decryptedBytes = decryptedStream.ToArray();
					return Encoding.UTF8.GetString(decryptedBytes);
				}
			}
		}
	}
}