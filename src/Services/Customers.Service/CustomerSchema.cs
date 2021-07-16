using Customers.Data.Models;
using Customers.Data.Repositories;
using Customers.Service.GraphTypes;
using GraphQL;
using GraphQL.Types;
using System;

namespace Customers.Service
{
	public class CustomerSchema : Schema 
	{
		public CustomerSchema(QueryObject query, IServiceProvider sp) : base(sp)
		{
			Query = query;
		}

		public class QueryObject : ObjectGraphType<object>
		{
			public QueryObject(ICustomersRepository repository)
			{
				Name = "Queries";
				Description = "The base query for all the entities in our object graph.";

				FieldAsync<CustomerObject, Customer>(
					"customer",
					"Gets a customer by its unique identifier.",
					new QueryArguments(
						new QueryArgument<NonNullGraphType<IdGraphType>>
						{
							Name = "id",
							Description = "The unique GUID of the customer."
						}),
					context => repository.GetByIdAsync(context.GetArgument("id", Guid.Empty)));
			}
		}
	}
}
