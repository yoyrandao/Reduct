using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Reduct.DataAccess;

namespace Reduct.Registrars
{
	public class TypeRegistrar
	{
		public static void Register(IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<RedisConfiguration>(configuration.GetSection("Redis"));

			services.AddSingleton(x => x.GetRequiredService<IOptions<RedisConfiguration>>().Value); 
		}
	}
}