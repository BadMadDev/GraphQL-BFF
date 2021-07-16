using GraphQL.Types;
using Orders.Data.Models;

namespace Orders.Service.GraphTypes
{
	public class OrderObject : ObjectGraphType<Order>
	{
		public OrderObject()
		{
			Name = nameof(Order);
			Description = "A order";

			Field(m => m.Id).Description("Identifier of the movie");
			Field(
				name: "OrderEntries",
				description: "Entries of the order",
				type: typeof(ListGraphType<OrderEntryObject>),
				resolve: m => m.Source.OrderEntries);
		}
	}
}
