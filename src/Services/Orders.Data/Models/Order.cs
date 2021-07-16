using System;
using System.Collections.Generic;

namespace Orders.Data.Models
{
	public class Order
	{
		public Guid Id { get; set; }
		public Guid CustomerId { get; set; }

		public DateTime Date { get; set; }
		public decimal Tax { get; set; }
		public decimal Total { get; set; }

		public IList<OrderEntry> OrderEntries { get; set; } = new List<OrderEntry>();

		public void AddEntry(OrderEntry entry)
		{
			OrderEntries.Add(entry);
		}
	}
}
