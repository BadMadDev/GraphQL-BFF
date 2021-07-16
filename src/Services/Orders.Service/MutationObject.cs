using System;
using GraphQL;
using GraphQL.Types;
using Orders.Data.Models;
using Orders.Data.Repositories;
using Orders.Service.GraphTypes;

namespace Orders.Service
{
	public class MutationObject : ObjectGraphType<object>
	{
		public MutationObject(IOrdersRepository repository)
		{
			Name = "Mutations";
			Description = "The base mutation for all the entities in our object graph.";

			FieldAsync<OrderObject, Order>(
				"addEntry",
				"Add entry to an order.",
				new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>>
					{
						Name = "id",
						Description = "The unique GUID of the movie."
					},
					new QueryArgument<NonNullGraphType<OrderEntryReviewInputObject>>
					{
						Name = "orderEntries",
						Description = "Review for the movie."
					}),
				context =>
				{
					var id = context.GetArgument<Guid>("id");
					var review = context.GetArgument<OrderEntry>("entry");
					return repository.AddEntryToOrderAsync(id, review);
				});
		}
	}
}