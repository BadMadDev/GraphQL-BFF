using Orders.Service.Models;

namespace Orders.Service.Mappings
{
	public static class OrdersMapping
	{
		public static Order ToModel(this Data.Models.Order order)
		{
			return new()
			{
				Id = order.Id
			};
		}
	}
}