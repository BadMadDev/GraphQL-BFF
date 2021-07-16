using System;
using GraphQL;
using GraphQL.Types;
using Orders.Data.Models;
using Orders.Data.Repositories;
using Orders.Service.GraphTypes;

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
		}
	}
}