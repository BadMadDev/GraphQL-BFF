using System.IO;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Orders.Service
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var configuration = GetConfiguration();

			CreateHostBuilder(configuration, args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(IConfiguration configuration, string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseServiceProviderFactory(new AutofacServiceProviderFactory())
				.ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

		private static IConfiguration GetConfiguration()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables();

			return builder.Build();
		}
	}
}
