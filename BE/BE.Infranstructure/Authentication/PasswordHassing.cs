using BE.Application.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BE.Infranstructure.Authentication;

public class PasswordHassing : IPasswordHasing
{
	private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
	private static readonly int SaltSize = 16;
	private static readonly int HashSize = 20;
	private static readonly int Iterations = 1000;

	public string HassPassword(string password)
	{
		byte[] salt;
		rng.GetBytes(salt = new byte[SaltSize]);
		var key = new Rfc2898DeriveBytes(password, salt, Iterations);
		var hash = key.GetBytes(HashSize);

		var hashBytes = new byte[SaltSize + HashSize];
		Array.Copy(salt, 0, hashBytes, 0, SaltSize);
		Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

		var base64Hash = Convert.ToBase64String(hashBytes);

		return base64Hash;
	}

	public bool VerifyPassword(string password, string bass64Hash)
	{
		var hashBytes = Convert.FromBase64String(bass64Hash);
		var salt = new byte[SaltSize];
		Array.Copy(hashBytes, 0, salt, 0, SaltSize);

		var key = new Rfc2898DeriveBytes(password, salt, Iterations);
		byte[] hash = key.GetBytes(HashSize);

		for (int i = 0; i < HashSize; i++)
		{
			if (hashBytes[i + SaltSize] != hash[i]) return false;
		}
		return true;
	}
}
