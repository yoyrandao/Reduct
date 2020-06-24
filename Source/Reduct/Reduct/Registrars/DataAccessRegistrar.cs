using Microsoft.Extensions.DependencyInjection;

using Reduct.DataAccess;

namespace Reduct.Registrars
{
	public class DataAccessRegistrar
	{
		public static void Register(IServiceCollection services)
		{
			services.AddTransient<ILinkRepository, LinkRepository>();
		}
	}
}