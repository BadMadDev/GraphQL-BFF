using GraphQL.Types;
using Orders.Data.Models;

namespace Orders.Service.GraphTypes
{
	public sealed class OrderEntryObject : ObjectGraphType<OrderEntry>
	{
		public OrderEntryObject()
		{
			Name = nameof(OrderEntry);
			Description = "A entry of the order";

			Field(r => r.Name).Description("Name of the order entry");
			Field(r => r.Description).Description("Description of the order entry");
			Field(r => r.Price).Description("Price of the order entry");
		}
	}
}