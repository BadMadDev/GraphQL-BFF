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

			Field(r => r.Description).Description("Name of the reviewer");
		}
	}
}