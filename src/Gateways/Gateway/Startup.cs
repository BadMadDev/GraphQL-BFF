using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Gateway
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddHttpClient("Customers", c => c.BaseAddress = new Uri("http://customers-api:5010/graphql"));
			services.AddHttpClient("Orders", c => c.BaseAddress = new Uri("http://orders-api:5020/graphql"));

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
