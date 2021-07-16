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

			Field(m => m.Id).Description("Identifier of the order");
			Field(m => m.CustomerId).Description("Identifier of the orders customer");
			Field(m => m.Date).Description("Date of the order");
			Field(m => m.Tax).Description("Tax of the order");
			Field(m => m.Total).Description("Total of the order");
			Field(
				name: "OrderEntries",
				description: "Entries of the order",
				type: typeof(ListGraphType<OrderEntryObject>),
				resolve: m => m.Source.OrderEntries);
		}
	}
}
