using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Reduct.Providers
{
	public class UrlHashProvider
	{
		public string GetHashed(string fullUrl)
		{
			var salt = Encoding.UTF8.GetBytes(DateTime.Now.ToString(CultureInfo.InvariantCulture));
			
			var hashAlgo = new HMACMD5(salt);
			var data = hashAlgo.ComputeHash(Encoding.UTF8.GetBytes(fullUrl));
			
			var builder = new StringBuilder();

			foreach (var @byte in data)
			{
				builder.Append(@byte.ToString("X2").ToLower());
			}

			return builder.ToString().Substring(0, MAX_URL_CHARACTER_LENGTH);
		}

		private const int MAX_URL_CHARACTER_LENGTH = 8;
	}
}