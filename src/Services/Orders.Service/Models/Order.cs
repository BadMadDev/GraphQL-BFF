using System;
using System.Collections.Generic;

namespace Orders.Service.Models
{
	public class Order
	{
		public Guid Id { get; set; }
		public Guid CustomerId { get; set; }

		public DateTime Date { get; set; }
		public decimal Tax { get; set; }
		public decimal Total { get; set; }

		public IList<OrderEntry> OrderEntries { get; set; }
	}
}
