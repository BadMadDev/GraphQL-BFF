using System;

namespace Orders.Data.Models
{
	public class OrderEntry
	{
		public Guid Id { get; set; }

		public Guid? OrderId { get; set; }
		public Order Order { get; set; }
	}
}
