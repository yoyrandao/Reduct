using System;

namespace Reduct.Providers
{
	public class UrlValidationProvider
	{
		public bool Validate(string url) => Uri.IsWellFormedUriString(url, UriKind.Absolute);
	}
}