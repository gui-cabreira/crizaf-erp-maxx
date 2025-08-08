using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MaxTek.ERP.BLL;

internal sealed class Seguranca
{
	private static readonly string _passPhrase = "FlSoftware";

	private static readonly string _saltValue = "MaxTek";

	private static readonly string _hashAlgorithm = "SHA1";

	private static readonly int _passwordIterations = 2;

	private static readonly string _initVector = "@1B2c3D4e5F6g7H8";

	private static readonly int _keySize = 256;

	public static string Criptografar(string texto)
	{
		string result = string.Empty;
		if (texto != null && texto.Length > 0)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(_initVector);
			byte[] bytes2 = Encoding.ASCII.GetBytes(_saltValue);
			byte[] bytes3 = Encoding.UTF8.GetBytes(texto);
			PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(_passPhrase, bytes2, _hashAlgorithm, _passwordIterations);
			byte[] bytes4 = passwordDeriveBytes.GetBytes(_keySize / 8);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Mode = CipherMode.CBC;
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(bytes4, bytes);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes3, 0, bytes3.Length);
			cryptoStream.FlushFinalBlock();
			byte[] inArray = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			result = Convert.ToBase64String(inArray);
		}
		return result;
	}

	public static string Decriptografar(string texto)
	{
		string result = string.Empty;
		if (texto != null && texto.Length > 0)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(_initVector);
			byte[] bytes2 = Encoding.ASCII.GetBytes(_saltValue);
			byte[] array = Convert.FromBase64String(texto);
			PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(_passPhrase, bytes2, _hashAlgorithm, _passwordIterations);
			byte[] bytes3 = passwordDeriveBytes.GetBytes(_keySize / 8);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Mode = CipherMode.CBC;
			ICryptoTransform transform = rijndaelManaged.CreateDecryptor(bytes3, bytes);
			MemoryStream memoryStream = new MemoryStream(array);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
			byte[] array2 = new byte[array.Length];
			int count = cryptoStream.Read(array2, 0, array2.Length);
			memoryStream.Close();
			cryptoStream.Close();
			result = Encoding.UTF8.GetString(array2, 0, count);
		}
		return result;
	}
}
