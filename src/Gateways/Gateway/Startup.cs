using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Gateway.Config;
using GraphQL.Server.Ui.Altair;
using Microsoft.Extensions.Configuration;

namespace Gateway
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			UrlsConfig urls = new UrlsConfig();
			Configuration.GetSection(UrlsConfig.SettingsKey).Bind(urls);

			services.AddHttpClient("Customers", c => c.BaseAddress = new Uri(urls.Customers));
			services.AddHttpClient("Orders", c => c.BaseAddress = new Uri(urls.Orders));

			services.AddGraphQLServer()
				.AddRemoteSchema("Customers", ignoreRootTypes: false)
				.AddRemoteSchema("Orders", ignoreRootTypes: false)
				.AddTypeExtensionsFromFile("Stiching.graphql");
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseGraphQLAltair(new AltairOptions() { }, "/ui/altair");

			app.UseEndpoints(e =>
			{
				e.MapGraphQL().WithOptions(
					new GraphQLServerOptions
					{
						Tool = { Enable = false }
					});
			});
		}
	}
}
