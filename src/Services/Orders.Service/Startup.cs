using Autofac;
using GraphQL.Server;
using GraphQL.Server.Ui.Altair;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Orders.Data.Context;
using Orders.Data.Repositories;
using Orders.Service.Services;

namespace Orders.Service
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

			services.AddTransient<IOrdersService, OrdersService>();
			services.AddTransient<IOrdersRepository, OrdersRepository>();

			services.AddEntityFrameworkInMemoryDatabase();
			services.AddDbContext<OrderContext>(context => { context.UseInMemoryDatabase("OrdersDatabase"); });

			services.AddGraphQL(
					(options, provider) =>
					{

						var graphOptions = Configuration.GetSection("GraphQL").Get<GraphQLOptions>();

						options.ComplexityConfiguration = graphOptions.ComplexityConfiguration;
						options.EnableMetrics = graphOptions.EnableMetrics;

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
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Orders.Service", Version = "v1" });
			});
		}

		public virtual void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
			builder.RegisterType<OrdersRepository>().As<IOrdersRepository>().InstancePerLifetimeScope();
			builder.RegisterType<DocumentWriter>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<QueryObject>().AsSelf().SingleInstance();
			builder.RegisterType<OrderSchema>().AsSelf().SingleInstance();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orders.Service v1"));
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseGraphQL<OrderSchema>();
			app.UseGraphQLAltair(new AltairOptions() { }, "/ui/altair");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
