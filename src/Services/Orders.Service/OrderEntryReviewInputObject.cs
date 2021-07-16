using GraphQL.Types;
using Orders.Data.Models;

namespace Orders.Service
{
	public sealed class OrderEntryReviewInputObject : InputObjectGraphType<OrderEntry>
	{
		public OrderEntryReviewInputObject()
		{
			Name = "OrderEntryInput";
			Description = "A entry of the order";

			Field(r => r.Id).Description("Id of an order entry.");
			Field(r => r.Description).Description("Desciption of the order entry");
		}
	}
}