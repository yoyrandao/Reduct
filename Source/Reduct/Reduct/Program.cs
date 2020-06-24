using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Reduct
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			string environment;

			#if DEBUG
			environment = "Development";
			#elif RELEASE
			environment = "Release";
			#endif

			return Host.CreateDefaultBuilder(args)
			    .UseEnvironment(environment)
			    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
			    .ConfigureAppConfiguration((context, builder) =>
			    {
				    builder.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json");
			    });
		}
	}
}