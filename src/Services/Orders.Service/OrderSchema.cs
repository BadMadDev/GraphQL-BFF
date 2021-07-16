using GraphQL.Types;
using System;

namespace Orders.Service
{
	public class OrderSchema : Schema
	{
		public OrderSchema(QueryObject query, MutationObject mutation, IServiceProvider sp) : base(sp)
		{
			Query = query;
			Mutation = mutation;
		}
	}
}
