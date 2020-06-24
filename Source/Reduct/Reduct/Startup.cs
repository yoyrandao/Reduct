using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Reduct.Registrars;

namespace Reduct
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			TypeRegistrar.Register(services, Configuration);
			DataAccessRegistrar.Register(services);
			CommonRegistrar.Register(services);
			
			services.AddControllers();
			services.AddCors();
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(builder =>
			{
				builder.WithMethods("GET", "POST");
				builder.AllowAnyHeader();
				builder.AllowAnyOrigin();
			});
			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}