using GraphQL;
using GraphQL.Types;
using Orders.Data.Models;
using Orders.Data.Repositories;
using Orders.Service.GraphTypes;
using System;
using System.Linq;

namespace Orders.Service
{
	public class QueryObject : ObjectGraphType<object>
	{
		public QueryObject(IOrdersRepository repository)
		{
			Name = "Queries";
			Description = "The base query for all the entities in our object graph.";

			FieldAsync<OrderObject, Order>(
				"order",
				"Gets a order by its unique identifier.",
				new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>>
					{
						Name = "id",
						Description = "The unique GUID of the orders."
					}),
				context => repository.GetByIdAsync(context.GetArgument("id", Guid.Empty)));


			FieldAsync<ListGraphType<OrderObject>>("orders",
				resolve: async context =>
				{
					var orders = await repository.GetOrdersAsync();

					return orders.ToList();
				});

			FieldAsync<ListGraphType<OrderObject>>("ordersByCustomer",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>>
					{
						Name = "id",
						Description = "The unique GUID of the customer."
					}),
				resolve: async context =>
				{
					var orders = await repository.GetOrdersByCustomerIdAsync(context.GetArgument("id", Guid.Empty));

					return orders.ToList();
				});
		}
	}
}