using System;

namespace Orders.Service.Models
{
	public class OrderEntry
	{
		public Guid Id { get; set; }

		public Guid? OrderId { get; set; }
		public Order Order { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price{ get; set; }
	}
}
