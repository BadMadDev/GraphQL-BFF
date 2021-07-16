using Customers.Data.Context;
using Customers.Data.Repositories;
using Customers.Service.Services;
using GraphQL.Server;
using GraphQL.Server.Ui.Altair;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Customers.Service
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddTransient<ICustomersService, CustomersService>();
			services.AddTransient<ICustomersRepository, CustomersRepository>();

			services.AddEntityFrameworkInMemoryDatabase();
			services.AddDbContext<CustomerContext>(context => { context.UseInMemoryDatabase("CustomersDatabase"); });

			services.AddGraphQL(
					(options, provider) =>
					{
						
						var graphQLOptions = Configuration
							.GetSection("GraphQL")
							.Get<GraphQLOptions>();
						options.ComplexityConfiguration = graphQLOptions.ComplexityConfiguration;
						options.EnableMetrics = graphQLOptions.EnableMetrics;
						
						var logger = provider.GetRequiredService<ILogger<Startup>>();
						options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
					})
				// Adds all graph types in the current assembly with a singleton lifetime.
				.AddGraphTypes()
				// Add GraphQL data loader to reduce the number of calls to our repository. https://graphql-dotnet.github.io/docs/guides/dataloader/
				.AddDataLoader()
				.AddSystemTextJson();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customers.Service", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customers.Service v1"));
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseGraphQLAltair(new AltairOptions());

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
