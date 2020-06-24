using Microsoft.Extensions.DependencyInjection;

using Reduct.Providers;

namespace Reduct.Registrars
{
	public class CommonRegistrar
	{
		public static void Register(IServiceCollection services)
		{
			services.AddTransient<UrlHashProvider>();
			services.AddTransient<UrlValidationProvider>();
		}
	}
}