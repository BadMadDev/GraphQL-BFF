using System.Linq;
using Orders.Service.Models;

namespace Orders.Service.Mappings
{
	public static class OrdersMapping
	{
		public static Order ToModel(this Data.Models.Order order)
		{
			return new()
			{
				Id = order.Id,
				CustomerId = order.CustomerId,
				Date = order.Date,
				Tax = order.Tax,
				Total = order.Total,
				OrderEntries = order.OrderEntries.Select(e => e.ToModel()).ToList()
			};
		}

		public static OrderEntry ToModel(this Data.Models.OrderEntry orderEntry)
		{
			return new()
			{
				Id = orderEntry.Id,
				Name = orderEntry.Name,
				Price = orderEntry.Price,
				Description = orderEntry.Description
			};
		}
	}
}